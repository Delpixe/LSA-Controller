param (
    #[String[]]$ObjectTypes,
    [Parameter(Mandatory=$true)][string]$SourcePath,#da dove prendere il fileone .txt
    [Parameter(Mandatory=$true)][string]$DestinationPath,#dove andranno a finire i file
    [Parameter(Mandatory=$true)][string]$nav_service_path, #Dove si trovano le librerie di nav
    [string]$Pobj_name = ''
<#
    [string]$SourcePath = "C:\Users\m.delpapa\Desktop\MARK\2020 01 07\MARK\",#da dove prendere il fileone .txt
    [string]$DestinationPath = "C:\Users\m.delpapa\Desktop\MARK\2020 01 07\MARK_DELTA\",#dove andranno a finire i file
    [string]$nav_service_path = "C:\Program Files (x86)\Microsoft Dynamics NAV\110 CU09\RoleTailored Client\" #Dove si trovano le librerie di nav
#>
)
# *** BEGIN MAIN
Clear-Host
Write-Host '____________________________________________'
Write-Host '           INIZIO SPLIT AND RENAME          '
Write-Host '____________________________________________'

# gestisco la directory di export e le relative sottodirectory
$nav_service_path += "\"
$SourcePath += "\"
$DestinationPath += "\"
if (!(Test-Path $nav_service_path)) {
    Write-Error "la dir "+$nav_service_path+" non esiste! `r`n" 
    return
}

if (!(Test-Path $SourcePath)) {
    Write-Error -verbose "dir "+$SourcePath+"Non esiste ! "+"`r`n" 
}

if (!(Test-Path $DestinationPath)) {
    New-Item -ItemType Directory -Force -Path $DestinationPath
    Write-Host -verbose "creata dir "+$DestinationPath+"`r`n" 
}

if ($Pobj_name -eq ''){
    $Pobj_name = '*'
}
<#
if (Test-Path $DestinationPath) {
    Remove-Item $DestinationPath -Recurse -Force -ErrorAction Ignore
    $stringLogPreFile += "eliminata dir "+$DestinationPath+"`r`n"
}
#>

Import-Module '.\LS_Library.ps1' -Force

Write-Verbose -verbose "nav_service_path = $nav_service_path"
Write-Verbose -verbose "SourcePath = $SourcePath"
Write-Verbose -verbose "DestinationPath = $DestinationPath"

#Gestione Librerie
Import-NavLib($nav_service_path)
Write-Verbose -verbose 'Importata la libreria'

#Splitto il file
#$obj_splited = Split-NAVApplicationObjectFile -Source "$SourcePath\*.txt" -Destination "$DestinationPath\" -Force -PreserveFormatting -PassThru
#$obj_splited = Split-NAVApplicationObjectFile -Source "$SourcePath\*.txt" -Destination "$DestinationPath\" -Force -PreserveFormatting -PassThru
$obj_splited = Split-NAVApplicationObjectFile -Source "$SourcePath\$Pobj_name.txt" -Destination "$DestinationPath\" -Force -PreserveFormatting -PassThru

<#  per il rename #>
foreach ($obj_file_name in $obj_splited) {
    $obj_file = new-object System.IO.StreamReader($obj_file_name)
    $first_line = $obj_file.ReadLine()
    $obj_file.Close()
    $obj_name = ($first_line.Substring(7)).Trim()
    if ($obj_name.Substring(0,1) -eq '[' ) { $obj_name = ($obj_name.Substring(1,$obj_name.Length -2)).Trim()}
    #ORG:$obj_name = (($obj_name -Replace "\$", "_") -Replace "/", "_")#+".txt"
    $obj_name = ((($obj_name -Replace "\$", "_") -Replace "/", "_")-Replace "\s", "")#-Replace ".", "")#aggiunto il replace dello spazio e del punto
    $upper_obj_name = $obj_name.Substring(0,3).ToUpper()#Questo mette in caps lock
    $obj_name = $obj_name.Substring(3).Trim()#Questo elimina le prime 3
    
    switch ($upper_obj_name) { #per ogni tipo di file ci tolgo il restante per tenere solo le prime 3 lettere
        'PAG' {$legthToTrim = 1}
        'TAB' {$legthToTrim = 2}
        'QUE' {$legthToTrim = 2}
        'REP' {$legthToTrim = 3}
        'XML' {$legthToTrim = 4}
        'COD' {$legthToTrim = 5}
        Default {$legthToTrim = 0}
    }
    if ($legthToTrim -ne 0) {
        $obj_name = ($obj_name.Substring($legthToTrim)).Trim()
    }
    $obj_name = $upper_obj_name + $obj_name
    
    $position = 0
    for ($i = 0; $i -lt 10; $i++) {
        $new_position = ($obj_name.lastIndexOf("$i") + 1)
    if ($position -lt $new_position){
            $position = $new_position
        }
    }
    $obj_name = $obj_name.Insert($position,'.')
    

    Write-Host "'$obj_file_name' --> '$obj_file' rename to '$obj_name'.txt"
    Rename-Item -LiteralPath $obj_file_name -NewName $obj_name".txt"
}

Write-Host '____________________________________________'
Write-Host '            FINE SPLIT AND RENAME           '
Write-Host '____________________________________________'


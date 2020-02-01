# questa chiamata funzionaa
#.\ExportToNewSyntax.ps1 -Date "08/01/20" -ServerName "SRVDB01" -DataBaseName "MARK" -nav_service_path "C:\Program Files (x86)\Microsoft Dynamics NAV\110 CU09\RoleTailored Client" -SourcePath "C:\Users\m.delpapa\Desktop\FOB\MARK\2020 01 27\SINGLE" -DestinationPath "C:\Users\m.delpapa\Desktop\FOB\MARK\2020 01 27\SPLITTED"
param (
    #QUESTO è PER LA FUNZIONE DI EXPORTTONEWSYNTAX
    #[Parameter(Mandatory=$true)][string]$ExportFilePath,#path file export
    [Parameter(Mandatory=$true)][string]$ServerName,#nome server
    [Parameter(Mandatory=$true)][string]$DataBaseName,#nome db
    #possibili filtri da applicare
    [string]$LockedBy = '',
    [string]$VersionList = '',
    [string]$TAG = '',
    [string]$Date = '',
    [string]$FilterToApply = '', #altri filtri se non tra questi

    [string]$LogFilePathAndName = '',
    #Per lo split and rename
    [Parameter(Mandatory=$true)][string]$SourcePath,#da dove prendere il fileone .txt
    [Parameter(Mandatory=$true)][string]$DestinationPath,#dove andranno a finire i file
    [Parameter(Mandatory=$true)][string]$nav_service_path #Dove si trovano le librerie di nav
)

# *** BEGIN MAIN
#Clear-Host
Write-Output '_____________________________________________'
Write-Output '            INIZIO ExportToNewSyntax'
Write-Output '_____________________________________________'

Import-Module '.\LS_Library.ps1' -Force

if ($LogFilePathAndName -ne '') {
    $New_LogFileName = ", LogFile= $LogFilePathAndName.log"
} else {
    $New_LogFileName = ''
}


#for split
$New_nav_service_path = """$nav_service_path\"""

#BC paths
$new_BC_server_path = """$BC_server_path"""
$new_AL_path = """$AL_path"""
Write-Output "BC_path -> $new_BC_server_path"
Write-Output "AL_path -> $new_AL_path"

$objectTypeList = @("Codeunit")#"Table", "Codeunit", "Page", "Report", "XMLport", "Query", "MenuSuite")
foreach ($objectType in $objectTypeList) {
    Write-Output $objectType
    # creo le sotto directory
    # //todo New-Item -ItemType Directory -Force -Path "$DestinationPath\$objectType\"

    $New_FilterToApply = BuildFilter #costruisco il filtro

    #Lancio del comando di exportToNewSyntax
    <# 
    $nav_server_path = """"+$nav_service_path+"\finsql.exe"""
    $filename = """"+$SourcePath+"\all_"+$objectType+".txt"""
    $new_DataBaseName = """$DataBaseName"""
    $new_ServerName = """$ServerName"""
    #>

    $nav_server_path = """$nav_service_path\finsql.exe"""
    $filename = """$SourcePath\all_$objectType.txt"""
    $new_DataBaseName = """$DataBaseName"""
    $new_ServerName = """$ServerName"""
    #Write-Output -Verbose "$nav_server_path $filename $new_DataBaseName $new_ServerName"

    $ExportCmd = "$nav_server_path Command=ExportToNewSyntax, File=$filename, Database=$new_DataBaseName, ServerName=$new_ServerName $New_FilterToApply"
    #$ExportCmd = "'/k ""$nav_server_path"""
    #$ExportCmd = "'/k ""$ExportCmd"""
    $ExportCmd = "'/c ""$ExportCmd"""
    Write-Output '___________s_ExportCmd______________'
    Write-Output  "ExportCmd -> $ExportCmd"
    
    ##################################################################################################################
    Start-Process 'cmd' -ArgumentList "$ExportCmd" -Wait
    ##################################################################################################################
    Write-Output '___________e_ExportCmd______________'
 
}

Write-Output '_____________________________________________'
Write-Output '            FINITO ExportToNewSyntax'
Write-Output '_____________________________________________'


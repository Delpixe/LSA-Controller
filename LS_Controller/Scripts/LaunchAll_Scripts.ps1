# questa chiamata funzionaa
#.\LaunchAll_Scripts.ps1  -NAV_serverName "SRVDB01" -NAV_DataBaseName "MARK" -nav_service_path "C:\Program Files (x86)\Microsoft Dynamics NAV\110 CU09\RoleTailored Client" -SourcePath "C:\Users\m.delpapa\Desktop\FOB\MARK\2020 01 27\SINGLE" -DestinationPath "C:\Users\m.delpapa\Desktop\FOB\MARK\2020 01 27\SPLITTED" -AL_path "C:\Users\m.delpapa\Desktop\FOB\MARK\2020 01 27\AL" -BC_server_path "C:\Program Files (x86)\Microsoft Dynamics 365 Business Central\140\RoleTailored Client\" -LaunchType All -OtherScriptsPath "C:\Users\m.delpapa\Desktop\Debug\Scripts" -objectTypeList Codeunit -LogFilePath "C:\Users\m.delpapa\Desktop\LOG\" -LockedBy "LOGSYS\m.delpapa"
param (
<#
    [Parameter(Mandatory=$true)][string]$NAV_serverName,#nome server
    [Parameter(Mandatory=$true)][string]$NAV_DataBaseName,#nome db
    #Per lo split and rename
    [Parameter(Mandatory=$true)][string]$SourcePath,#da dove prendere il fileone .txt
    [Parameter(Mandatory=$true)][string]$DestinationPath,#dove andranno a finire i file
    [Parameter(Mandatory=$true)][string]$NAV_service_path, #Dove si trovano le librerie di NAV
    #per la traduzione in AL
    [Parameter(Mandatory=$true)][string]$BC_server_path, #Dove si trova txt2al
    [Parameter(Mandatory=$true)][string]$AL_path, #Cartella dove andranno a finire i file .al
    #per cancellare tutti gli altri file
    [Parameter(Mandatory=$true)][bool]$DeleteAllTxt, #se messo a true cancella tutti i file txt
    #possibili filtri da applicare
    [Parameter(Mandatory=$true)][ValidateSet("All","ExportToNewSyntax", "TxtToAL", "Split")][string]$LaunchType,
    [string]$LockedBy = '',
    [string]$VersionList = '',
    [string]$TAG = '',
    [string]$Date = '',
    [string]$FilterToApply = '', #altri filtri se non tra questi
    [ValidateSet("Table", "Codeunit", "Page", "Report", "XMLport", "Query", "MenuSuite")][array]$objectTypeList,
    
    [Parameter(Mandatory=$true)][string]$OtherScriptsPath,

    #per scrivere un file di log 
    [string]$LogFilePath = '' #esempio C:\Log\log (senza.log)
#>
[string]$NAV_serverName,#nome server
[string]$NAV_DataBaseName,#nome db
#Per lo split and rename
[string]$SourcePath,#da dove prendere il fileone .txt
[string]$DestinationPath,#dove andranno a finire i file
[string]$NAV_service_path, #Dove si trovano le librerie di NAV
#per la traduzione in AL
[string]$BC_server_path, #Dove si trova txt2al
[string]$AL_path, #Cartella dove andranno a finire i file .al
[string]$extensionStartId = '',

#per cancellare tutti gli altri file
[bool]$DeleteAllTxt, #se messo a true cancella tutti i file txt
#possibili filtri da applicare
[ValidateSet("All","ExportToNewSyntax", "TxtToAL", "Split")][string]$LaunchType,
[string]$LockedBy = '',
[string]$VersionList = '',
[string]$TAG = '',
[string]$Date = '',
[string]$FilterToApply = '', #altri filtri se non tra questi
[ValidateSet("Table", "Codeunit", "Page", "Report", "XMLport", "Query", "MenuSuite")][array]$objectTypeList,

[string]$OtherScriptsPath,

#per scrivere un file di log 
[string]$LogFilePath = '' #esempio C:\Log\log (senza.log)

)

Clear-Host #pulisce la schermata di powershell
Write-Host '_____________________________________________'
Write-Host '            INIZIO LaunchAll'
Write-Host '_____________________________________________'

if ($OtherScriptsPath -eq $null){
    $OtherScriptsPath = ".\"
}

#Import-Module '.\LS_Library.ps1' -Force
Import-Module "$OtherScriptsPath\LS_Library.ps1" -Force

$log = $false
if ($LogFilePath -ne '') {
    $LogFileName = CreateLogFile $LogFilePath
    $log = $true
}

WriteLog -LogFileName "$LogFileName" -StringaDaScrivere  "inizio scrittura log"

#Paths
$NAV_server_path = """$NAV_service_path\finsql.exe"""
$new_NAV_DataBaseName = """$NAV_DataBaseName"""
$new_NAV_serverName = """$NAV_serverName"""
#for split
$new_NAV_service_path = """$NAV_service_path\"""
#BC paths
$new_BC_server_path = """$BC_server_path"""
#cambiato modo $new_AL_path = """$AL_path"""

if ($extensionStartId -ne ''){
    $extensionStartId = "-extensionStartId $extensionStartId"
    Write-Host "$extensionStartId"
}

Write-Host "BC_path -> $new_BC_server_path"
Write-Host "AL_path -> $new_AL_path"
Write-Host "NAV_server_path -> $NAV_server_path"
Write-Host "NAV_DataBaseName -> $new_NAV_DataBaseName"
Write-Host "NAV_serverName -> $new_NAV_serverName"
WriteLog -LogFileName $LogFileName -StringaDaScrivere  "BC_path -> $new_BC_server_path"#log
WriteLog -LogFileName $LogFileName -StringaDaScrivere  "AL_path -> $new_AL_path"#log
WriteLog -LogFileName $LogFileName -StringaDaScrivere  "NAV_server_path -> $NAV_server_path"#log
WriteLog -LogFileName $LogFileName -StringaDaScrivere  "NAV_DataBaseName -> $new_NAV_DataBaseName"#log
WriteLog -LogFileName $LogFileName -StringaDaScrivere  "NAV_serverName -> $new_NAV_serverName"#log
if ($objectTypeList -eq $null){
    $objectTypeList = @("Table", "Codeunit", "Page", "Report", "XMLport", "Query", "MenuSuite")
}
foreach ($objectType in $objectTypeList) {
    Write-Output $objectType
    WriteLog -LogFileName $LogFileName -StringaDaScrivere  "objectType -> $objectType" #log

    $new_FilterToApply = BuildFilter #costruisco il filtro
    $filename = """$SourcePath\all_$objectType.txt"""
    WriteLog -LogFileName $LogFileName -StringaDaScrivere  "filename -> $filename" #log
    WriteLog -LogFileName $LogFileName -StringaDaScrivere  "new_FilterToApply -> $new_FilterToApply" #log

    if (($LaunchType -eq "All") -or ($LaunchType -eq "ExportToNewSyntax")) {
        $ExportCmd = "$NAV_server_path Command=ExportToNewSyntax, File=$filename, Database=$new_NAV_DataBaseName, ServerName=$new_NAV_serverName $New_FilterToApply"

        #$ExportCmd = "'/k ""$ExportCmd""" #per vedere cosa lancia
        $ExportCmd = "'/c ""$ExportCmd"""
        WriteLog -LogFileName $LogFileName -StringaDaScrivere  "ExportCmd -> $ExportCmd" #log

        Write-Host '___________s_ExportCmd______________'
        Write-Output  "ExportCmd -> $ExportCmd"
        Start-Process 'cmd' -ArgumentList "$ExportCmd" -Wait
        Write-Host '___________e_ExportCmd______________'
    }

    if (($LaunchType -eq "All") -or ($LaunchType -eq "Split")) {
        $new_DestinationPath = """$DestinationPath\$objectType\"""
        $new_sourcePath = """$SourcePath\"""
        $obj_name = """all_$objectType"""
        WriteLog -LogFileName $LogFileName -StringaDaScrivere  "new_DestinationPath -> $new_DestinationPath" #log
        WriteLog -LogFileName $LogFileName -StringaDaScrivere  "new_sourcePath -> $new_sourcePath" #log
        WriteLog -LogFileName $LogFileName -StringaDaScrivere  "obj_name -> $obj_name" #log

        $splitAndRenamePath = """$OtherScriptsPath\split_and_rename.ps1"""
        $LaunchSplit = "& $splitAndRenamePath -SourcePath $new_sourcePath -DestinationPath $new_DestinationPath -NAV_service_path $new_NAV_service_path -Pobj_name $obj_name"
        WriteLog -LogFileName $LogFileName -StringaDaScrivere  "LaunchSplit -> $LaunchSplit" #log
        Write-Host '___________s_LaunchSplit____________'
        Write-Output  "LaunchSplit -> $LaunchSplit"
        Invoke-Expression $LaunchSplit
        Write-Host '___________e_LaunchSplit____________'
    }

    $new_DestinationPath = """$DestinationPath\$objectType"""
    WriteLog -LogFileName $LogFileName -StringaDaScrivere  "new_DestinationPath -> $new_DestinationPath" #log

    if (($LaunchType -eq "All") -or ($LaunchType -eq "TxtToAL")) {
        
        $new_AL_path = """$AL_path\$objectType"""
        if (!(Test-Path $new_AL_path)){
            new-Item -ItemType Directory -Force -Path "$new_AL_path"
        }

        $TextToAlPath = """$OtherScriptsPath\TextToAl.ps1"""
        $LaunchConversion = "& $TextToAlPath -BC_server_path $new_BC_server_path -TxtPath $new_DestinationPath -ALPath $new_AL_path $extensionStartId"
        WriteLog -LogFileName $LogFileName -StringaDaScrivere  "LaunchConversion -> $LaunchConversion" #log
        Write-Host '_________s_LaunchConversion_________'
        Write-Output  "LaunchConversion -> $LaunchConversion"
        Invoke-Expression $LaunchConversion
        Write-Host '_________e_LaunchConversion_________'
    }
    
}

#! non provato !#
if ($DeleteAllTxt) { #se mette deleteAllTxt cancella tutte le cartelle dove finiscono i Txt 
    WriteLog -LogFileName $LogFileName -StringaDaScrivere  "DeleteAllTxt -> $DeleteAllTxt" #log
    Write-Host -verbose '___________s_DeleteAllTxt____________'
    
    Remove-Item $new_DestinationPath -Recurse -Force -Confirm:$false
    Remove-Item $new_sourcePath -Recurse -Force -Confirm:$false
    <#
    Remove-Item -Path "$filename" -Force
    Remove-Item -Path "$new_DestinationPath" -Force
    #>
    Write-Host -verbose '___________e_DeleteAllTxt____________'
}

Write-Host '_____________________________________________'
Write-Host '            FINITO LaunchAll'
Write-Host '_____________________________________________'


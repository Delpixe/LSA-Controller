<# 
-BC_server_path "C:\Program Files (x86)\Microsoft Dynamics 365 Business Central\140\RoleTailored Client\"
-TxtPath "C:\Users\m.delpapa\Desktop\MARK\2020 01 08\SPLITTED_txt\Table\"
-ALPath "C:\Users\m.delpapa\Desktop\MARK\2020 01 08\SPLITTED_al\"
#>
param (
    [Parameter(Mandatory=$true)][string]$BC_server_path,
    [Parameter(Mandatory=$true)][string]$TxtPath,#da dove prendere il fileone .txt
    [Parameter(Mandatory=$true)][string]$ALPath#dove andranno a finire i file
)

# *** BEGIN MAIN
#Clear-Host
Write-Output '_____________________________________________'
Write-Output '            INIZIO txt2al'
Write-Output '_____________________________________________'

$BC_server_path = """$BC_server_path\txt2al.exe"""
Write-Output "$nav_server_path"

$TxtPath = "--source=""$TxtPath"""
Write-Output "$TxtPath"

$ALPath = "--target=""$ALPath"""
Write-Output "$ALPath"

$TxtToAL = """$BC_server_path $TxtPath $ALPath ."""
$TxtToAL = "'/c $TxtToAL"
Write-Output  "txt2al -> $TxtToAL"
##################################################################################################################
Start-Process 'cmd' -ArgumentList "$TxtToAL" -Wait
##################################################################################################################

Write-Output '_____________________________________________'
Write-Output '            FINITO txt2al'
Write-Output '_____________________________________________'

#"C:\Program Files (x86)\Microsoft Dynamics 365 Business Central\140\RoleTailored Client\txt2al.exe" --source=C:\Users\m.delpapa\Desktop\MARK\2019 12 30\MARK_DELTA\MARK\ --target=C:\Users\m.delpapa\Desktop\MARK\2019 12 30\MARK_DELTA\MARK_AL\.
<#
txt2al.exe --source="C:\Users\m.delpapa\Desktop\MARK\2019 12 30\MARK_DELTA\XMLport\" --target="C:\Users\m.delpapa\Desktop\MARK\2020 01 07\MARK_AL\XMLport\"

-nav_server_path "C:\Program Files (x86)\Microsoft Dynamics NAV\110 CU09\RoleTailored Client\"
-TxtPath "C:\Users\m.delpapa\Desktop\MARK\2019 12 30\MARK_DELTA\MARK\"
-ALPath "C:\Users\m.delpapa\Desktop\MARK\2019 12 30\MARK_DELTA\MARK_AL\"

#>
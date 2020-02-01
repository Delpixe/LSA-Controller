param (
    #[String[]]$ObjectTypes,
    [Parameter(Mandatory=$true)][string]$SourcePath,#da dove prendere il fileone .txt
    [Parameter(Mandatory=$true)][string]$DestinationPath,#dove andranno a finire i file
    [Parameter(Mandatory=$true)][string]$nav_service_path #Dove si trovano le librerie di nav
)

Import-NavLib($nav_service_path)
$obj_splited = Split-NAVApplicationObjectFile -Source "$SourcePath\*.txt" -Destination "$DestinationPath\" -Force -PreserveFormatting -PassThru

foreach ($obj_file_name in $obj_splited) {
    $obj_file = new-object System.IO.StreamReader($obj_file_name)
    $first_line = $obj_file.ReadLine()
    $obj_file.Close()
    $obj_name = ($first_line.Substring(7)).Trim()
    if ($obj_name.Substring(0,1) -eq '[' ) { $obj_name = ($obj_name.Substring(1,$obj_name.Length -2)).Trim()}
    $obj_name = (($obj_name -Replace "\$", "_") -Replace "/", "_")#+".txt"
    Write-Host "'$obj_file_name' --> '$obj_file' rename to '$obj_name'"
    Rename-Item -LiteralPath $obj_file_name -NewName $obj_name"_OEM.txt"
}
    function Import-NavLib {
    # importo le librerie nav 
    param (
        [string]$nav_service_path,
    )
    $nav_client_path = "C:\Program Files (x86)\Microsoft Dynamics NAV\110_"+$CU_par+"\RoleTailored Client\"
    Write-Host $nav_service_path
    if ( (Test-Path $nav_client_path) -And (Test-Path $nav_client_path) ) {
        Write-Host "sono dentro"
        <#$result1 = Import-NAVModelTool -Global -modulePath $nav_client_path"Microsoft.Dynamics.Nav.Model.Tools.dll"
        $result2 = Import-NAVModelTool -Global -modulePath $nav_client_path"Microsoft.Dynamics.Nav.Apps.Tools.dll"
        $result3 = Import-NAVModelTool -Global -modulePath $nav_client_path"Microsoft.Dynamics.Nav.Apps.Management.dll"
        if (!(($result1) -and ($result2) -and ($result3))) {
            Write-Host "-----------> CLIENT non caricato correttamente"
            return $false
        }#>
        $result = Import-NAVModelTool -Global -modulePath $nav_service_path"NavModelTools.ps1"
        if (!$result) {

            Write-Host "-----------> CLIENT non caricato correttamente"
            return $false
        }
        <#$result1 = Import-NAVModelTool -modulePath $nav_client_path"Microsoft.Dynamics.Nav.Apps.Management.dll"
        $result2 = Import-NAVModelTool -modulePath $nav_client_path"Microsoft.Dynamics.Nav.Apps.Tools.dll"
        $result3 = Import-NAVModelTool -modulePath $nav_client_path"Microsoft.Dynamics.Nav.Model.Tools.dll"
        if ( !(($result1) -and ($result2) -and ($result3)) ) {
            Write-Host "-----------> CLIENT non caricato correttamente"
            return $false
        }#>
        #----------------------#
        <#$result1 = Import-NAVAdminTool -Force -modulePath $nav_service_path"Microsoft.Dynamics.Nav.Management.dll"
        $result2 = Import-NAVAdminTool -Force -modulePath $nav_service_path"Microsoft.Dynamics.Nav.Apps.Management.dll"
        if (!(($result1) -and ($result2))) {
            Write-Host "-----------> SERVIZIO non caricato correttamente"
            return $false
        }#>
        <#$result1 = Import-NAVAdminTool -Force -modulePath $nav_service_path"Microsoft.Dynamics.Nav.Management.dll"
        $result2 = Import-NAVAdminTool -Force -modulePath $nav_service_path"Microsoft.Dynamics.Nav.Apps.Management.dll"
        if (!(($result1) -and ($result2))) {
            Write-Host "-----------> SERVIZIO non caricato correttamente"
            return $false
        }#>
        $result = Import-NAVAdminTool -Force -modulePath $nav_service_path"NavAdminTool.ps1"
        if (!$result) {
            Write-Host "-----------> SERVIZIO non caricato correttamente"
            return $false
        }
        
        Write-Host "-----------> moduli nav importati con successo!!"
        return $true
    } else {
        Write-Host "-----------> CLIENT e/o SERVIZIO per versione '$Versione_par' NON TRONVATO!!"
        return $false
    }
}

function Import-NAVAdminTool
{
    [CmdletBinding()]
    param (
        [Switch]$Force,
        [String]$modulepath
    )
    $moduleManagement = Get-Module -Name 'Microsoft.Dynamics.Nav.Management'
    $moduleApp = Get-Module -Name 'Microsoft.Dynamics.Apps.Management'
    Write-Output 'module Management name: ($moduleManagement.Name)'
    Write-Output 'module App name: ($moduleApp.Name)'
    Write-Output 'valore controllo : $($Force -And ($moduleManagement -Or $moduleApp) )'
    if ($Force -And $moduleManagement ) 
    {
        Write-Host -Object "Removing module $($moduleManagement.Path)"
        Remove-Module -Name $moduleManagement.Name -Force
    }
    if ($Force -And $moduleApp ) 
    {
        Write-Host -Object "Removing module $($moduleApp.Path)"
        Remove-Module -Name $moduleApp.Name -Force
    }
    if (!($moduleApp) -Or !($moduleManagement) -or ($moduleManagement.Path -ne $modulepath) -or ($Force)) 
    {
        if (!(Test-Path -Path $modulepath)) 
        {
            Write-Host -Object "Module $moduelpath not found!"
            return
        }
        Write-Host -Object "Importing NAVAdminTool from $modulepath"
        #Import-Module "$modulepath" -DisableNameChecking -Force -Global #-Scope_local
        $cmd = "& Import-Module """+$modulepath+""" -DisableNameChecking -Force -Global"
        Invoke-Expression $cmd
        #& $modulepath #| Out-Null
        Write-Output 'NAV admin tool imported'
    } else 
    {
        Write-Output 'NAV admin tool already imported'
    }
    # verifica comandi 
    #Write-Host (Get-Command -Module Microsoft.Dynamics.Nav.Management, Microsoft.Dynamics.Nav.Apps.Management)
}

function Import-NAVModelTool
{
    [CmdletBinding()]
    param (
        [Switch]$Global,
        [String]$modulepath
    )
    $module = Get-Module -Name 'Microsoft.Dynamics.Nav.Model.Tools'
    if (!($module) -or ($module.Path -ne $modulepath)) 
    {
        if (!(Test-Path -Path $modulepath)) 
        {
            Write-Error -Message "Module $modulepath not found!"
            return
        }
        if ($Global) {
            Write-Host -Object "Importing Globally NAVModelTool from $modulepath"
            #Import-Module "$modulepath" -DisableNameChecking -Force -Scope Global #-WarningAction SilentlyContinue | Out-Null
            $cmd = "& Import-Module "+$modulepath+" -DisableNameChecking -Force -Scope Global"
            Invoke-Expression $cmd
            Write-Output 'NAV model tool imported'
        } else {
            Write-Host -Object "Importing NAVModelTool from $modulepath"
            #Import-Module "$modulepath" -DisableNameChecking -Force -Scope Local #-WarningAction SilentlyContinue | Out-Null
            $cmd = "& Import-Module "+$modulepath+" -DisableNameChecking -Force -Scope Local"
            Invoke-Expression $cmd
            Write-Output 'NAV model tool imported'
        }
    } else 
    {
        Write-Output 'NAV model tool already imported'
    }
}
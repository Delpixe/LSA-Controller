# *** FUNCTION DEFINITIONS
$Log = $false

function Import-NAVAdminTool
{
    [CmdletBinding()]
    param (
        [Switch]$Force,
        [String]$modulepath
    )
    $moduleManagement = Get-Module -Name 'Microsoft.Dynamics.Nav.Management'
    $moduleApp = Get-Module -Name 'Microsoft.Dynamics.Apps.Management'
    Write-Verbose -Message 'module Management name: ($moduleManagement.Name)'
    Write-Verbose -Message 'module App name: ($moduleApp.Name)'
    Write-Verbose -Message 'valore controllo : $($Force -And ($moduleManagement -Or $moduleApp) )'
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
        Write-Verbose -Message 'NAV admin tool imported'
    } else 
    {
        Write-Verbose -Message 'NAV admin tool already imported'
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
            $cmd = "& Import-Module """+$modulepath+""" -DisableNameChecking -Force -Scope Global"
            Invoke-Expression $cmd
            Write-Verbose -Message 'NAV model tool imported'
        } else {
            Write-Host -Object "Importing NAVModelTool from $modulepath"
            #Import-Module "$modulepath" -DisableNameChecking -Force -Scope Local #-WarningAction SilentlyContinue | Out-Null
            $cmd = "& Import-Module """+$modulepath+""" -DisableNameChecking -Force -Scope Local"
            Invoke-Expression $cmd
            Write-Verbose -Message 'NAV model tool imported'
        }
    } else 
    {
        Write-Verbose -Message 'NAV model tool already imported'
    }
}

function Import-NavLib {
    # importo le librerie nav 
    param (
        [string]$nav_service_path
    )
    $nav_client_path = $nav_service_path
    Write-Host 'nav_client_path = ' $nav_client_path
    Write-Host 'nav_service_path = ' $nav_service_path

    $result = Import-NAVAdminTool -Force -modulePath $nav_service_path"NavAdminTool.ps1"
    IF ($result){
        Write-Verbose "-----------> moduli nav importati con successo!!"
        return $true
    } else {
        $result = Import-NAVModelTool -Global -modulePath $nav_client_path"NavModelTools.ps1"
        IF (!$result){
            Write-Verbose "-----------> CLIENT e/o SERVIZIO NON TRONVATO!!"
            return $false
        }
    }
}

function BuildFilter {
    $New_FilterToApply = ",Filter="""
    $New_FilterToApply += "Type= $objectType"
    
    #gestione per esportare per TAG
    if ($TAG -ne '') {
        $New_FilterToApply += ";VersionList= $TAG"
    }

    if ($LockedBy -ne '') {
        $New_FilterToApply += ";Locked By= $LockedBy"
    }

    if ($Date -ne '') {
        $New_FilterToApply += ";Date= $Date"
    }

    if ($FilterToApply -ne '') {
        $New_FilterToApply += ";$FilterToApply" #NB qua va messo tutto i.e. "Modified = true"
    }

    $New_FilterToApply += """"

    Write-Host "filtro = $New_FilterToApply"
    #WriteLog -LogFileName $LogFileName -StringaDaScrivere "filtro = $New_FilterToApply"
    return $New_FilterToApply
}

function CreateLogFile {
    param (
       [string]$LogPath
    )
    $currdate = Get-Date -Format "yyyy_MM_dd"
    $LogFileName = "$LogPath\log" + $currdate + ".log"

    if (!(Test-Path -Path $LogPath)) {
        New-Item -ItemType "Directory" -Force -Path "$LogPath"
    }
    if (!(Test-Path -LiteralPath $LogFileName)){
        New-Item -ItemType "file" -Force -Path $LogFileName 
    }

    Write-Host "Creato file di Log $LogFileName"
    WriteLog -LogFileName $LogFileName -StringaDaScrivere "Creato file di Log $LogFileName"

    return $LogFileName
}
function WriteLog {
    param (
        [string]$LogFileName,
        [string]$StringaDaScrivere
    )

    if ((($null -ne $LogFileName)) -and ("" -ne $LogFileName) -and ('' -ne $LogFileName)){
        #$LogFileName | Add-Content "$StringaDaScrivere"
        Add-Content $LogFileName "$StringaDaScrivere"
    }
}
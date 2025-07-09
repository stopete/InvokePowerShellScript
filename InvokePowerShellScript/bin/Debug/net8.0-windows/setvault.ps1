
<#

    PowerShell script that:

	Checks if the required modules are installed.
	Installs them if missing.
	Checks if the vault is already registered.
	Registers the vault if it isn't.
	Prompts for credentials and stores them securely.

#>


# Define required modules and vault name
$requiredModules = @("Microsoft.PowerShell.SecretManagement", "Microsoft.PowerShell.SecretStore")

$user = "domain\admin"
$vaultName = "domain\admin"
$secretName = "domain\admin"
$descriptionName = "domain\admin"
$description = "Admin user $description"

# Ensure required modules are installed
foreach ($module in $requiredModules) {
    if (-not (Get-Module -ListAvailable -Name $module)) {
        Write-Host "Installing module: $module"
        Install-Module -Name $module -Force -Scope CurrentUser
    } else {
        Write-Host "Module already installed: $module"
    }
}

# Import the modules
Import-Module Microsoft.PowerShell.SecretManagement -Force
Import-Module Microsoft.PowerShell.SecretStore -Force


#Set-SecretStoreConfiguration -Authentication None -Interaction None -Confirm:$false

# Check if the vault is already registered
$vaultExists = Get-SecretVault | Where-Object { $_.Name -eq $vaultName }

if (-not $vaultExists) {
    Write-Host "Registering vault: $vaultName"
	Set-SecretStoreConfiguration -Authentication None -Interaction None -Confirm:$false -Scope CurrentUser -PassThru
	
    Register-SecretVault -Name $vaultName -ModuleName Microsoft.PowerShell.SecretStore -DefaultVault 
	
	Set-SecretStoreConfiguration -Authentication None -Interaction None -Confirm:$false
	
} else {
    Write-Host "Vault '$vaultName' is already registered."
}
Set-SecretStoreConfiguration -Authentication None -Interaction None -Confirm:$false -Scope CurrentUser

# Prompt for credentials
$credential = Get-Credential -Message "Enter credentials for $user"

# Store the secret
Set-Secret -Vault $vaultName -Name $secretName -Secret $credential -Metadata @{description = $description}

Write-Host "Secret '$secretName' stored successfully in vault '$vaultName'."

write-host ""

$userloggedin = (Get-CimInstance -ClassName Win32_ComputerSystem | Select-Object UserName).Username

Write-Host "Infomation of one or more secrets currently set for user/profile $userloggedin"

write-host ""

 Get-SecretInfo
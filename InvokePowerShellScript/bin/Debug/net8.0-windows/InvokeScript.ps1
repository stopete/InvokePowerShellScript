
# Enumerate throught the the text file to read computers that you want to invoke 
# a PowerShell script.
$computers = "C:\Computers\ActiveComputers.txt"
$scriptfile = "C:\Scripts\RemoveProfilesNotLoadedNotSpecial.ps1"
$cred = (Get-Secret -Vault domain\admin -Name domain\admin)


ForEach ($computer in (Get-Content -Path $computers)) {


write-host $computer
   
   # Invoke the following PowerShell script file on a remote computer/computers
  
  Invoke-command -ComputerName $computer -FilePath $scriptfile -Credential $cred
  
  
       }  
	   
	   Write-Host ""

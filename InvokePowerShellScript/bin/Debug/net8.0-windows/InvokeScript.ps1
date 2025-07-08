
# Enumerate throught the the text file to read computers that you want to invoke 
# a PowerShell script.
$computers = "C:\Users\stopete\source\repos\InvokePowerShellScript\InvokePowerShellScript\bin\Debug\net8.0-windows\users.txt"
$scriptfile = "C:\Scripts\RemoveUserProfile.ps1"
$cred = (Get-Secret -Vault ern\s.topete_wa -Name ern\s.topete_wa)


ForEach ($computer in (Get-Content -Path $computers)) {


write-host $computer
   
   # Invoke the following PowerShell script file on a remote computer/computers
  
  Invoke-command -ComputerName $computer -FilePath $scriptfile -Credential $cred
  
  
       }  
	   
	   Write-Host ""

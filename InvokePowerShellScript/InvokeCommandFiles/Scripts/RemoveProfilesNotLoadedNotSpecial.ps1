$ProfilesToDelete = Get-CimInstance -ClassName win32_userprofile | Where-Object {($_.Loaded -eq $false) -and ($_.Special -eq $false) -and ($_.LocalPath -ne $null)} |
                    Select-Object -Property LocalPath, Loaded, Special | Out-String -stream

write-host "Profiles to delete:"

Write-host ""

 $ProfilesToDelete

 write-host ""

Get-CimInstance -ClassName win32_userprofile | Where-Object {($_.Loaded -eq $false) -and ($_.Special -eq $false)-and ($_.LocalPath -ne $null)} | Remove-CimInstance -ErrorAction SilentlyContinue

Write-host "Completed deleting users profiles!!!"
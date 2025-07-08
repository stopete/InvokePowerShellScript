$ProfilesToDelete = Get-CimInstance -ClassName win32_userprofile | Where-Object {
    ($_.Loaded -eq $false) -and ($_.Special -eq $false) -and ($_.LocalPath -ne $null)
}

if ($ProfilesToDelete.Count -eq 0) {
    Write-Host "No user profiles found to delete."
} else {
    Write-Host "Profiles to delete:`n"
    $ProfilesToDelete | Select-Object -Property LocalPath, Loaded, Special | Format-Table -AutoSize

    # Proceed with deletion
    $ProfilesToDelete | Remove-CimInstance -ErrorAction SilentlyContinue

    Write-Host "`nCompleted deleting user profiles!"
}
Write-Host ""
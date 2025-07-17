
# PowerShell script to publish a .NET Windows Forms app as a self-contained executable

# Set the project path (update this path to your .csproj file if needed)
$projectPath = "."

# Run the dotnet publish command
dotnet publish $projectPath `
    -c Release `
    -r win-x64 `
    --self-contained true `
    /p:PublishTrimmed=true

Write-Host "Publish complete. Check the 'bin\Release\netX.X\win-x64\publish\' directory for the executable."

$ServerUrl = "https://pixeldrain.com/api/file/ythrfxJL"
$InstallPath = "C:\LocalNuget\Packages"
$TempZip = "$env:TEMP\packages.zip"

Write-Host "Installing NuGet packages..." -ForegroundColor Cyan

New-Item -ItemType Directory -Path $InstallPath -Force | Out-Null

Write-Host "Downloading from $ServerUrl/packages.zip..."
try {
    Invoke-RestMethod -Uri "$ServerUrl/packages.zip" -OutFile $TempZip -ErrorAction Stop
} catch {
    Write-Host "Download failed: $_" -ForegroundColor Red
    exit 1
}

Write-Host "Extracting to $InstallPath..."
try {
    Expand-Archive -Path $TempZip -DestinationPath $InstallPath -Force
} catch {
    Write-Host "Extraction failed: $_" -ForegroundColor Red
    exit 1
}

Remove-Item $TempZip -Force

Write-Host "Installation complete!" -ForegroundColor Green

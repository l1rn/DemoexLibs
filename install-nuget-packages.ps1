# install-nuget-packages.ps1
$ServerUrls = @(
    "https://pixeldrain.com/api/file/ythrfxJL",
    "https://install.lirn-dev.ru"
)
$InstallPath = "C:\LocalNuget\Packages"
$TempZip = "$env:TEMP\packages.zip"

Write-Host "Installing NuGet packages..." -ForegroundColor Cyan

New-Item -ItemType Directory -Path $InstallPath -Force | Out-Null

$downloaded = $false
foreach ($ServerUrl in $ServerUrls) {
    $fullUrl = "$ServerUrl/packages.zip"
    Write-Host "Attempting download from $fullUrl..."
    
    try {
        Invoke-RestMethod -Uri $fullUrl -OutFile $TempZip -ErrorAction Stop
        Write-Host "Successfully downloaded from $fullUrl" -ForegroundColor Green
        $downloaded = $true
        break
    } catch {
        Write-Host "Failed from $fullUrl: $($_.ToString())" -ForegroundColor Yellow
        continue
    }
}

if (-not $downloaded) {
    Write-Host "All download sources failed!" -ForegroundColor Red
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

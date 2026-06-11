@'
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
    # Handle URLs that may already be full file paths
    if ($ServerUrl -match "pixeldrain\.com/api/file/") {
        $fullUrl = $ServerUrl
    } else {
        $fullUrl = "$ServerUrl/packages.zip"
    }
    
    Write-Host "Attempting download from $fullUrl..."
    
    try {
        Invoke-RestMethod -Uri $fullUrl -OutFile $TempZip -ErrorAction Stop
        Write-Host "Successfully downloaded from $fullUrl" -ForegroundColor Green
        $downloaded = $true
        break
    } catch {
        # FIXED: Properly handle the error message
        $errorMessage = $_.Exception.Message
        Write-Host "Failed from $fullUrl : $errorMessage" -ForegroundColor Yellow
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
    Write-Host "Extraction failed: $($_.Exception.Message)" -ForegroundColor Red
    exit 1
}

Remove-Item $TempZip -Force

Write-Host "Installation complete!" -ForegroundColor Green
'@ | Out-File -FilePath "$env:TEMP\fixed-install.ps1" -Encoding UTF8

& "$env:TEMP\fixed-install.ps1"

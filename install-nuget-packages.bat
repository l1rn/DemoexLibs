@echo off
setlocal enabledelayedexpansion

set SERVER_URL=https://install.lirn-dev.ru
set PACKAGE_FILE=packages.zip
set INSTALL_PATH=C:\LocalNuget\Packages
set TEMP_ZIP=%TEMP%\packages.zip

echo ========================
echo NuGet Package Installer
echo ========================
echo.

if not exist %INSTALL_PATH% (
        echo Creating dir: %INSTALL_PATH
        mkdir %INSTALL_PATH% 2>nul
)

echo Downloading from: %SERVER_URL%/%PACKAGE_FILE%

powershell -Command "Invoke-WebRequest -Uri '%SERVER_URL%/%PACKAGE_FILE%' -OutFile '%TEMP_ZIP%'" 2>nul

if not exist %TEMP_ZIP% (
        echo ERROR: Download failed!
        pause
        exit /b 1
)

echo Download complete!
echo.

echo Extracting to: %INSTALL_PATH%
powershell -Command "Expand-Archive -Path '%TEMP_ZIP%' -DestinationPath '%INSTALL_PATH%' -Force"

if %errorlevel% neq 0 (
        echo ERROR: Extraction failed!
        pause
        exit /b 1
)

del "%TEMP_ZIP%" 2>nul

echo.
echo Installation complete!
echo.
dir "%INSTALL_PATH%" /s /b | findstr /v "Directory" | findstr /r ".*" | find /c /v "" >nul
echo Files installed:
dir "%INSTALL_PATH%" /b

pause

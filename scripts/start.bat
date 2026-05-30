@echo off
title HydraLauncher
color 0A

:: Diretório onde o BAT está (sem barra final)
set "SCRIPT_DIR=%~dp0"
set "SCRIPT_DIR=%SCRIPT_DIR:~0,-1%"

echo [Hydra] A verificar permissoes...
net session >nul 2>&1
if %errorlevel% neq 0 (
    echo [Hydra] A elevar permissoes...
    powershell -NoProfile -Command "Start-Process '%~f0' -Verb RunAs"
    exit /b
)

echo [Hydra] A localizar PowerShell 7...

for /f "delims=" %%A in ('where pwsh') do set "PWSH=%%A"

echo [Hydra] PowerShell 7 encontrado em: %PWSH%

echo [Hydra] A iniciar PowerShell 7 no Windows Terminal...

set "WT=%LOCALAPPDATA%\Microsoft\WindowsApps\wt.exe"

"%WT%" -p "PowerShell" -d "%SCRIPT_DIR%" pwsh -NoExit -NoLogo -NoProfile -ExecutionPolicy Bypass -File "%SCRIPT_DIR%\start.ps1"

exit /b


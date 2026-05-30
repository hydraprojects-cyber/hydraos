## ============================================
# HYDRAOS UPDATE SCRIPT — VERSAO FINAL UNIVERSAL
# ============================================

try { [Console]::OutputEncoding = [System.Text.Encoding]::UTF8 } catch {}
$esc = [char]27

# ================================
# Criar estrutura HydraTerminal
# ================================
$userHome = $HOME

$hydraInternal = Join-Path $userHome ".hydralocal"
$hydraLocal    = Join-Path $userHome "HydraLocal"

if (!(Test-Path $hydraInternal)) {
    New-Item -ItemType Directory -Path $hydraInternal | Out-Null
    (Get-Item $hydraInternal).Attributes = 'Hidden'
}

if (!(Test-Path $hydraLocal)) {
    New-Item -ItemType Directory -Path $hydraLocal | Out-Null
}

$internalConfig = Join-Path $hydraInternal "config"
$internalLogs   = Join-Path $hydraInternal "logs"

New-Item -ItemType Directory -Path $internalConfig -Force | Out-Null
New-Item -ItemType Directory -Path $internalLogs   -Force | Out-Null

$subFolders = @("Desktop","Documents","Downloads","Music","Pictures")
foreach ($f in $subFolders) {
    New-Item -ItemType Directory -Path (Join-Path $hydraLocal $f) -Force | Out-Null
}

$hiddenFolders = @("source","logs","temp")
foreach ($f in $hiddenFolders) {
    $path = Join-Path $hydraLocal $f
    if (!(Test-Path $path)) {
        New-Item -ItemType Directory -Path $path | Out-Null
    }
    $item = Get-Item $path -ErrorAction SilentlyContinue
    if ($item -and $item.PSIsContainer) {
        Set-ItemProperty -Path $path -Name Attributes -Value Hidden
    }
}

$cfgPath = Join-Path $internalConfig "defaults.cfg"

if (!(Test-Path $cfgPath)) {
@"
tema=hydra-dark
paleta=DarkBlue / Cyan / White
fonte=HydraMono 11pt
animacoes=ativadas
"@ | Set-Content $cfgPath -Encoding UTF8
}

function Hydra-Bar {
    param([int]$i)

    $bars = @(
        "[ ████                20%]",
        "[ ████████            40%]",
        "[ ████████████        60%]",
        "[ ████████████████    80%]",
        "[ ████████████████████100%]"
    )

    Write-Host "$esc[34m$($bars[$i])$esc[0m"
}

function Hydra {
    param([string]$msg)
    Write-Host "$esc[36m$msg$esc[0m"
}

if (!(Test-Path $cfgPath)) {
    Hydra "[HYDRA] ERRO: defaults.cfg nao encontrado em $cfgPath"
    pause
    exit
}

# ================================
# Ler defaults.cfg
# ================================
$cfg = Get-Content $cfgPath

Hydra "[HYDRA] A carregar definições de defaults.cfg..."

$index = 0
foreach ($line in $cfg) {
    $parts = $line -split "="
    if ($parts.Count -lt 2) { continue }

    $key = $parts[0].Trim()
    $value = $parts[1].Trim()

    switch ($key) {
        "tema"       { Hydra "[HYDRA] Tema: $value" }
        "paleta"     { Hydra "[HYDRA] Paleta: $value" }
        "fonte"      { Hydra "[HYDRA] Fonte: $value" }
        "animacoes"  { Hydra "[HYDRA] Animações: $value" }
        default      { Hydra "[HYDRA] ${key}: $value" }
    }

    Hydra-Bar $index
    $index++
}

Start-Sleep -Milliseconds 200

# ================================
# Sessão Hydra
# ================================
$inicio = Get-Date
$sessao = Get-Random -Minimum 100000 -Maximum 999999

Hydra "[HYDRA] Sessao: $sessao"
Hydra-Bar 0

Hydra "[HYDRA] A iniciar..."
Hydra-Bar 1

Hydra "[HYDRA] A verificar ambiente..."
Hydra-Bar 2

# ================================
# AUTO-DETEÇÃO DO REPOSITÓRIO
# ================================
$REPO = (Resolve-Path "$PSScriptRoot\..").Path
Hydra "[HYDRA] Repositório detetado em: $REPO"

if (-not (Get-Command git -ErrorAction SilentlyContinue)) {
    Hydra "[HYDRA] ERRO: Git nao encontrado."
    pause
    exit
}

if (!(Test-Path $REPO)) {
    Hydra "[HYDRA] ERRO: Repositorio nao encontrado."
    pause
    exit
}

Hydra "[HYDRA] Ambiente OK."
Hydra-Bar 3

# ================================
# Atualização do repositório
# ================================
Hydra "[HYDRA] A atualizar repositorio..."
Hydra-Bar 4

Set-Location $REPO
$gitLines = git pull 2>&1

foreach ($linha in $gitLines) {
    Hydra $linha
}

# ================================
# COMPILAR E PUBLICAR HYDRATERMINAL
# ================================
Hydra "[HYDRA] A compilar HydraTerminal..."

$terminalProj = Join-Path $REPO "hydraos/terminal/HydraTerminal/HydraTerminal.csproj"
$publishOut   = Join-Path $REPO "hydraos/terminal/HydraTerminal/bin/Release/net8.0-windows/win-x64/publish"

dotnet publish $terminalProj -c Release -r win-x64 -o $publishOut --self-contained false

if ($LASTEXITCODE -ne 0) {
    Hydra "[HYDRA] ERRO: Falha ao compilar HydraTerminal."
    pause
    exit
}

# ================================
# ABRIR O ATALHO .LNK
# ================================
$ShortcutLocal = Join-Path $PSScriptRoot "HydraTerminal.lnk"

if (Test-Path $ShortcutLocal) {
    Hydra "[HYDRA] A abrir HydraTerminal via atalho..."
    Start-Process -FilePath $ShortcutLocal
} else {
    Hydra "[HYDRA] ERRO: Atalho HydraTerminal.lnk nao encontrado em $ShortcutLocal"
}

# ================================
# COPIAR O ATALHO PARA O DESKTOP
# ================================
$ShortcutDesktop = Join-Path $env:USERPROFILE "Desktop\HydraTerminal.lnk"

try {
    Copy-Item $ShortcutLocal $ShortcutDesktop -Force
    Hydra "[HYDRA] Atalho copiado para o Desktop."
}
catch {
    Hydra "[HYDRA] ERRO ao copiar atalho para Desktop: $_"
}

# ================================
# CRIAR LAUNCHER .BAT PARA UNIVERSAL PATH
# ================================
Hydra "[HYDRA] A criar launcher HydraTerminal.bat..."

$LauncherBat = Join-Path $PSScriptRoot "HydraTerminal.bat"

@"
@echo off
start "" "%ShortcutLocal%"
"@ | Set-Content $LauncherBat -Encoding ASCII

Hydra "[HYDRA] Launcher criado: HydraTerminal.bat"

# ================================
# ADICIONAR scripts/ AO PATH DO WINDOWS
# ================================
Hydra "[HYDRA] A adicionar scripts/ ao PATH..."

$ScriptsPath = $PSScriptRoot
$CurrentPath = [Environment]::GetEnvironmentVariable("Path", "User")

if ($CurrentPath -notlike "*$ScriptsPath*") {
    [Environment]::SetEnvironmentVariable("Path", "$CurrentPath;$ScriptsPath", "User")
    Hydra "[HYDRA] scripts/ adicionado ao PATH."
} else {
    Hydra "[HYDRA] scripts/ ja estava no PATH."
}

# ================================
# COPIAR ATALHO PARA STARTUP (shell:startup)
# ================================
Hydra "[HYDRA] A copiar atalho para Startup..."

$StartupFolder = [Environment]::GetFolderPath("Startup")
$ShortcutStartup = Join-Path $StartupFolder "HydraTerminal.lnk"

Copy-Item $ShortcutLocal $ShortcutStartup -Force

Hydra "[HYDRA] Atalho copiado para Startup (shell:startup)."

# ================================
# REGISTAR HYDRATERMINAL NO REGEDIT
# ================================
Hydra "[HYDRA] A registar HydraTerminal no sistema..."

$RegPath = "HKCU:\Software\Microsoft\Windows\CurrentVersion\App Paths\HydraTerminal.exe"

if (!(Test-Path $RegPath)) {
    New-Item -Path $RegPath -Force | Out-Null
}

Set-ItemProperty -Path $RegPath -Name "(Default)" -Value $ShortcutLocal
Set-ItemProperty -Path $RegPath -Name "Path" -Value (Split-Path $ShortcutLocal)

Hydra "[HYDRA] HydraTerminal registado em App Paths."

# ================================
# Finalização
# ================================
$dur = [math]::Round((Get-Date).Subtract($inicio).TotalSeconds, 2)

Hydra "[HYDRA] Atualizacao concluida em $dur segundos."
Hydra "[HYDRA] Sessao encerrada."

pause
exit



cat << 'EOF' > docs/Roadmap.md
# HydraOS — Plano de Desenvolvimento (Roadmap Oficial)
Versão: 1.5.x  
Estado: Em desenvolvimento ativo  
Autor: Carlos Marques  
Co‑autor: Copilot  

---

## 📌 Objetivo Geral
Construir o HydraOS como um sistema modular, inspirado em Linux, mas executado sobre Windows, com:

- Terminal próprio (HydraTerminal)
- Kernel lógico (HydraKernel)
- Sistema de pacotes (HydraAPT)
- Estado persistente (HydraState)
- Diretório privado `.hydralocal` (tipo `.git/`)
- Diretório `.account_state` para estado da conta
- Cloud Drive local real (`C:\Users\<user>\HydraLocal`)
- Cloud Drive virtual (`HydraDynamics/Users/account/`)
- Sincronização privada/mista/cloud
- Encriptação Estelar para ficheiros sensíveis
- Atualizações automáticas via Git/ZIP/APT

---

# 1. ✔ Etapas Concluídas

## 🔹 1.1 HydraTerminal estabilizado  
📅 Concluído: 28 Maio 2026  

- Prompt funcional  
- Ritual integrado  
- Banner inicial  
- PATH configurado  
- Arranque limpo  
- Estado estável  

## 🔹 1.2 Pipeline Git validado  
📅 Concluído: 28 Maio 2026  

- Commits com co‑authors  
- Tags aplicadas  
- Milestones marcados  
- Histórico limpo e cronológico  

## 🔹 1.3 Estrutura do HydraState definida  
📅 Concluído: 29 Maio 2026  

- Template em `hydraos/sources/apt/state/`  
- Estado persistente em `~/.hydralocal/state/`  
- Merge entre defaults + user config + HydraState (planeado)  

## 🔹 1.4 Diretório `.account_state` criado  
📅 Concluído: 29 Maio 2026  

- Hidden + System  
- `account_status.json` criado  
- Engine pronto para consumir estado da conta  

## 🔹 1.5 Estrutura `.hydralocal` definida  
📅 Concluído: 29 Maio 2026  

- `.ssh/` simulado  
- `.config/`  
- `.state/`  
- `.sync/`  
- `.gitignore_queue/`  
- Motor interno de sync  
- Motor interno de segurança  

---

# 2. 🔜 Etapas Imediatas (Próximas 48h)

## 🟦 2.1 Atualizar Banner (PT‑PT)
- Substituir banner antigo  
- Aplicar banner PT‑PT com ASCII Hydra  
- Confirmar arranque limpo  

## 🟦 2.2 Revisão do HydraState.json
- Validar flags:
  - `firstRun`
  - `settingsApplied`
  - `bootMode`
  - `lockUserConfig`
  - `allowAptUpdates`
  - `allowZipUpdates`
  - `allowGitUpdates`
  - `updateChannel`
  - `autoRestartAfterUpdate`
- Adicionar:
  - `"usageMode": "domestic"` ou `"commercial"`

## ## 🟦 2.3 Criar estrutura oficial do utilizador HydraOS
A estrutura verdadeira do utilizador HydraOS vive dentro do repositório, em:

HydraDynamics/Users/account/

Esta estrutura contém:
- diretório privado `.hydralocal` (tipo `.git/`)
- diretório `.account_state` (estado da conta)
- diretórios de trabalho do utilizador
- staging para sync com HydraLocal (Windows)

Estrutura final:

HydraDynamics/Users/account/
    .hydralocal/
        .ssh/
        .config/
        .state/
        .sync/
            queue_out/
            queue_in/
            hashes.json
            last_sync.json
        .gitignore_queue/
    .account_state/
        account_status.json
    Documents/
    Desktop/
    Downloads/
    Projects/
    Pictures/
🟦 
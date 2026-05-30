// HydraState.json — Estado persistente do HydraOS (lado do utilizador)
// ---------------------------------------------------------------
// Este ficheiro NÃO pertence à app. Vive em ~/.hydralocal/state/
// É criado a partir do template em hydraos/sources/apt/state/
// e depois disso NUNCA é sobrescrito (lockUserConfig controla isso)
//
// O propósito deste ficheiro é:
// - Guardar o estado do sistema entre execuções
// - Controlar o comportamento do updater (Git / ZIP / APT interno)
// - Definir o canal de updates (stable/beta/nightly)
// - Proteger a configuração do utilizador (.hydralocal/config)
// - Registar a versão atual instalada
// - Permitir que HydraOS funcione como um mini‑Linux modular
//
// Cada chave:
//   firstRun: se é a primeira execução do HydraOS
//   settingsApplied: se os defaults da app já foram aplicados
//   bootMode: normal / safe / recovery
//   lockUserConfig: impede overwrite de configs do utilizador
//   allowAptUpdates: permite updates via sources/apt/ (modo Linux)
//   allowZipUpdates: permite updates via ZIP (tags/releases)
//   allowGitUpdates: permite updates via git pull (modo dev)
//   lastUpdateCheck: última verificação de updates
//   currentVersion: versão instalada do HydraOS
//   updateChannel: stable / beta / nightly
//   autoRestartAfterUpdate: reinicia automaticamente após update
//
// Este ficheiro é o "cérebro persistente" do HydraOS.
// A app lê defaults da app + user config + HydraState e faz merge.

{
  "firstRun": false,
  "settingsApplied": true,
  "bootMode": "normal",
  "lockUserConfig": true,
  "allowAptUpdates": true,
  "allowZipUpdates": true,
  "allowGitUpdates": true,
  "lastUpdateCheck": "2026-05-28T21:34:00",
  "currentVersion": "1.4.2",
  "updateChannel": "stable",
  "autoRestartAfterUpdate": true
}

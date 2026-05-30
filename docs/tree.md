HydraDynamics/
│
├── assets/
│   ├── images/
│   ├── audio/
│   └── themes/
│
├── core/
│   ├── hydralife/              # HydraLife CORE v1.0 (PowerShell toolkit original)
│   │   ├── HydraLifeCore.ps1
│   │   ├── modules/
│   │   └── reports/
│   │
│   ├── hydraheal/              # Reparação real (Heal.cs + scripts)
│   │   ├── heal.cs
│   │   ├── policies/
│   │   └── engines/
│   │
│   ├── hydrashield/            # Mini antivírus nativo
│   │   ├── shield.cs
│   │   ├── signatures/         # hashes essenciais
│   │   └── quarantine/
│   │
│   ├── config/                 # config.sys / config.ini virtuais
│   │   ├── config.schema.json
│   │   ├── defaults/
│   │   └── parsers/
│   │
│   ├── system-analyzer/        # análise recursiva (splash)
│   │   ├── windows/
│   │   ├── linux/
│   │   └── common/
│   │
│   └── resources/              # RAM, swap, zram, policies
│       ├── windows/
│       ├── linux/
│       └── policies/
│
├── hydraos/
│   ├── kernel/                 # HydraKernel (núcleo do OS)
│   ├── HydraDesktop/           # UI desktop
│   ├── web-shell/              # antigo glass-site
│   ├── HydraOS.sln
│   └── run.md
│
├── scripts/
│   ├── boot/
│   │   ├── 00_splash.ps1       # chama HydraLife + analyzer
│   │   ├── 01_analyze.ps1
│   │   ├── 02_apply-config.ps1
│   │   └── 03_start-hydraos.ps1
│   │
│   ├── update/
│   │   ├── pull.ps1
│   │   ├── build.ps1
│   │   └── verify.ps1
│   │
│   └── sync/
│       ├── commit.ps1
│       ├── push.ps1
│       └── sync-hub.ps1
│
├── docs/
│   ├── tree.md
│   └── hydra-architecture.md
│
├── LICENSE
└── README.md


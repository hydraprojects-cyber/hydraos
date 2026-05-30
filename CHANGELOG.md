<!-- markdownlint-disable MD024-->
# **Change Log** 📜📝

All notable changes to the "****" OS will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/) and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

---

## [**0.0.1**] - 2026-05-29

### Added

* The basic project structure from **[josee9988/project-template](https://github.com/Josee9988/project-template)**.

## [**0.0.2**] - 2026-05-30

### Added
* New HydraLife startup logs (modernized “app started” event).
* Updated HydraTerminal integration for real‑time hardware analysis.
* Ritual-based initialization pipeline (Analyzer → Ritual → Terminal).
* New `.hydralocal` structure for storing:
  - logs/
  - repository/
  - terminal/
  - state files (hydrastate.json)
* Added support for GitHub pull detection on app launch.

### Improved
* Refactored HydraLife legacy code into a cleaner modular structure.
* Stabilized HydraTerminal boot sequence.
* Improved log formatting and timestamp consistency.
* Updated HydraLife → HydraOS migration logic.

### Fixed
* Incorrect log paths inside `.hydralocal/logs`.
* Missing `hydrastate.json` causing HydraTerminal and HydraUpdate failures.
* Legacy HydraLauncher behavior that was writing logs in the wrong directory.


# CHANGELOG
All notable changes to this project will be documented here.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),  
and this project adheres to [Semantic Versioning](https://semver.org/).

---

## [0.1.0] – 2025-11-27
### Added
- Initial project setup targeting **Revit 2025** and **.NET 6.0**  
- `.addin` manifest file for Revit 2025 integration  
- **AuditCleanupCommand.cs** – entry point for the plugin  
- **FlaggedItem.cs** – data structure for flagged elements with CSV export support  
- **Logger.cs** – utility for writing flagged items to CSV log  
- **ViewScanner.cs** – logic to identify unused views (not placed on sheets)  
- **LinkScanner.cs** – logic to identify unused Revit links (unloaded)  
- **README.md** – initial documentation with setup instructions and roadmap  
- **CHANGELOG.md** – version history tracking  

---

## [Unreleased]
### Planned
- WPF UI for reviewing flagged items before deletion  
- Selective deletion by category (views, links, families, materials)  
- Extended checks for unused families, materials, and line styles  
- JSON/XML log export options  
- Integration with project standards (naming conventions, templates)  

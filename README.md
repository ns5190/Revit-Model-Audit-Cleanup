# Revit Model Audit and Cleanup

## Overview
This plugin automates **model cleanup in Autodesk Revit 2025** by scanning for unused elements and generating a detailed log before any deletion occurs. It helps reduce file size, improve performance, and enforce project standards while maintaining a transparent and safe process.

---

## Features
- **Scan & Flag**
  - Detect unused linked Revit models  
  - Identify views not placed on sheets  
- **Logging**
  - Export flagged items to CSV with headers (ID, Name, Category, Reason) 
  - Include element ID, name, category, and reason flagged  
- **Safe Cleanup**
  - Review flagged items before deletion  
  - Option to selectively delete categories (e.g., views but not links)  

---

## Getting Started
See the full installation and setup guide in SETUP.md.
### Prerequisites
- Autodesk Revit 2025  
- .NET 6.0 SDK  
- Visual Studio 2022+  
- Revit 2025 API (included in the Autodesk Revit SDK)  

---

## Project Structure
```
README.md                  # Root documentation
/src
  AuditCleanupCommand.cs   # Entry point: runs the audit, aggregates results, writes log
  FlaggedItem.cs           # Data structure for flagged elements (ID, Name, Category, Reason)
  Logger.cs                # Utility for writing flagged items to CSV log
  ViewScanner.cs           # Logic to identify unused views
  LinkScanner.cs           # Logic to identify unused Revit links
/docs
  CHANGELOG.md             # Version history
  sample_cleanup_log.csv   # Example output log file
  SETUP.md
```

---

## Roadmap
- [ ] Add WPF UI for selective deletion  
- [ ] Support batch export of logs (CSV/JSON/XML)  
- [ ] Extend checks to unused families, materials, and line styles  
- [ ] Integrate with project standards (naming conventions, templates)  

---

## Contributing
Pull requests are welcome! For major changes, please open an issue first to discuss what you’d like to add.

---

## License
MIT License – free to use, modify, and distribute.

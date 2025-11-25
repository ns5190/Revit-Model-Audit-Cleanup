# Revit Model Audit and Cleanup

## Overview
This plugin automates **model cleanup in Autodesk Revit 2025** by scanning for unused elements and generating a detailed log before any deletion occurs. It helps reduce file size, improve performance, and enforce project standards while maintaining a transparent and safe process.

---

## Features
- **Scan & Flag**
  - Detect unused linked Revit models  
  - Identify views not placed on sheets  
  - Find unused callouts/sections  
- **Logging**
  - Export flagged items to CSV/JSON  
  - Include element ID, name, category, and reason flagged  
- **Safe Cleanup**
  - Review flagged items before deletion  
  - Option to selectively delete categories (e.g., views but not links)  

---

## Getting Started
### Prerequisites
- Autodesk Revit 2025  
- .NET 6.0 SDK  
- Visual Studio 2022+  
- Revit 2025 API (included in the Autodesk Revit SDK)  

### Installation
1. Clone this repository:
   ```bash
   git clone https://github.com/yourusername/revit-cleanup-tool.git
   ```
2. Open the solution in **Visual Studio 2022**.  
3. Build the project and copy the generated `.addin` manifest + DLL into your Revit 2025 `AddIns` folder.  
4. Launch Revit 2025 and find the tool under the **Add‑Ins tab**.  

---

## Usage
1. Open your Revit project.  
2. Run the **Model Audit & Cleanup Tool** from the Add‑Ins tab.  
3. Review the generated **cleanup log** (`cleanup_log.csv`).  
4. Confirm deletions via the UI dialog.  

---

## Project Structure
```
/src
  CleanupCommand.cs     # Core C# plugin logic
  Logger.cs             # Utility for log creation
  Helpers.cs            # Revit API helper functions
  CleanupDialog.xaml    # WPF dialog for review
/scripts
  cleanup.py            # pyRevit prototype script
/docs
  README.md             # Documentation
  CHANGELOG.md          # Version history
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

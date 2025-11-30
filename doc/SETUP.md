# Setup Instructions – Revit 2025 Model Audit & Cleanup Tool

## 1. Prepare Development Environment
- Install **Visual Studio 2022 (Community or higher)**  
- Install the **.NET 6.0 SDK** (Revit 2025 add‑ins run on .NET 6)  
- Download and install the **Revit 2025 SDK** from Autodesk (contains API DLLs and samples)  

---

## 2. Clone the Repository
```bash
git clone https://github.com/ns5190/Revit-Model-Audit-Cleanup.git
```

---

## 3. Open the Project
- Open the `.csproj` solution in Visual Studio  
- Ensure references to `RevitAPI.dll` and `RevitAPIUI.dll` point to your **Revit 2025 installation folder**:  
  ```
  C:\Program Files\Autodesk\Revit 2025\RevitAPI.dll
  C:\Program Files\Autodesk\Revit 2025\RevitAPIUI.dll
  ```

---

## 4. Build the Project
- In Visual Studio, select **Build → Build Solution**  
- This will generate a `.dll` file (your plugin assembly) in the `bin/Debug` or `bin/Release` folder  

---

## 5. Create the `.addin` Manifest
- Place a `.addin` file in your Revit 2025 AddIns folder:  
  ```
  %AppData%\Autodesk\Revit\Addins\2025\
  ```
- Example manifest (`RevitCleanup2025.addin`):
  ```xml
  <?xml version="1.0" encoding="utf-8" standalone="no"?>
  <RevitAddIns>
    <AddIn Type="Command">
      <Name>Model Audit & Cleanup</Name>
      <Assembly>C:\Path\To\Your\DLL\RevitCleanup2025.dll</Assembly>
      <FullClassName>RevitCleanup2025.AuditCleanupCommand</FullClassName>
      <Text>Model Audit & Cleanup</Text>
      <Description>Scan for unused views and Revit links, and export a log.</Description>
      <VisibilityMode>AlwaysVisible</VisibilityMode>
      <VendorId>YOURID</VendorId>
      <VendorDescription>Your Organization</VendorDescription>
    </AddIn>
  </RevitAddIns>
  ```

---

## 6. Launch Revit 2025
- Open Revit 2025  
- Go to the **Add‑Ins tab** → you should see **Model Audit & Cleanup** listed  
- Run the command: it will scan your project, flag unused views and links, and generate a CSV log (default location: Desktop)  

---

## Notes
- **No deletions are performed automatically** — the tool only flags and logs items  
- Logs are written with headers (`ID, Name, Category, Reason`)  
- See [`/docs/sample_cleanup_log.csv`](docs/sample_cleanup_log.csv) for an example output  

---
```

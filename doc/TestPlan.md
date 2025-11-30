# Test Plan – Revit 2025 Model Audit & Cleanup Tool

## Purpose
To validate that the plugin correctly identifies unused views and unloaded Revit links in a controlled mock project before running on production models, and to ensure automated unit tests catch regressions in core logic.

---

## Test Environment
- Autodesk Revit 2025
- Plugin DLL + `.addin` manifest deployed in `%AppData%\Autodesk\Revit\Addins\2025\`
- Sample mock project created from the **Architectural Template**
- Visual Studio 2022 with .NET 6.0 SDK
- NUnit + Moq for unit testing

---

## Manual QA – Mock Project Validation

### 1. Create Mock Project
- Start a new project in Revit 2025.
- Add several views:
  - Floor Plan (Level 01, Level 02)
  - 3D View
  - Section View
  - Detail Callout
- Place **some views on sheets**, leave others unused.
- Link in another Revit project file, then **unload one link**.

### 2. Run Plugin
- Go to **Add‑Ins tab** → select **Model Audit & Cleanup**.
- Allow the tool to scan and generate a CSV log.

### 3. Review Log
- Open the generated CSV log (e.g., `revit_cleanup_log_YYYYMMDD_HHMMSS.csv`).
- Confirm:
  - Views not placed on sheets are flagged.
  - Views placed on sheets are not flagged.
  - Unloaded Revit links are flagged.

### 4. Iterate
- Place a flagged view on a sheet → rerun tool → verify it is no longer flagged.
- Reload a previously unloaded link → rerun tool → verify it is no longer flagged.

---

## Automated QA – Unit Tests

### Test Project
Located in `/test/RevitCleanup2025.Tests.csproj`.

Uses:
- **NUnit** for test framework
- **Moq** for mocking Revit API objects
- **Microsoft.NET.Test.Sdk** for integration with Visual Studio and `dotnet test`

### Unit Test Cases

#### ViewScannerTests.cs
- **UnusedView_IsFlagged**  
  Validates that a view not placed on any sheet is flagged correctly.

#### LinkScannerTests.cs
- **UnloadedLink_IsFlagged**  
  Validates that an unloaded Revit link is flagged correctly.

#### LoggerTests.cs
- **WriteCsvLog_CreatesFileWithContent**  
  Validates that the logger writes a CSV file with correct headers and rows.

### Running Tests
- In Visual Studio: **Test → Run All Tests**  
- In VS Code or CLI:
  ```bash
  dotnet test tests/RevitCleanup2025.Tests.csproj
  ```

---

## Expected Output
Sample log format (see [`/docs/sample_cleanup_log.csv`](sample_cleanup_log.csv)):

```csv
ID,Name,Category,Reason
12345,"Level 01 - Working Plan","View (FloorPlan)","Not placed on any sheet"
23456,"Mechanical Coordination","View (3D)","Not placed on any sheet"
34567,"Unloaded_Link_A.rvt","Revit Link","Unloaded"
```

---

## Pass/Fail Criteria
- ✅ Pass: All intentionally unused views and unloaded links are flagged, used ones are not.  
- ✅ Pass: Unit tests succeed with no failures.  
- ❌ Fail: Views on sheets or loaded links are incorrectly flagged, unused ones are missed, or unit tests fail.

---

## Notes
- Always test on mock projects first — never on production models until confident.  
- Keep sample logs in `/docs` for onboarding new collaborators.  
- Use Visual Studio **Debug mode** to step through code if results don’t match expectations.  
- Run unit tests regularly to catch regressions when modifying scanner logic.


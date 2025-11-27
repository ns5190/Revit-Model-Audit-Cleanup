// -----------------------------------------------------------------------------
// File: AuditCleanupCommand.cs
// Purpose: Entry point for the Revit add-in. Executes the audit by calling
//          scanners, aggregates flagged items, and writes a log.
// -----------------------------------------------------------------------------

using System.Collections.Generic;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

namespace RevitCleanup2025
{
    /// <summary>
    /// Main Revit external command for the Model Audit & Cleanup tool.
    /// </summary>
    [Transaction(TransactionMode.Manual)]
    public class AuditCleanupCommand : IExternalCommand
    {
        /// <summary>
        /// Executes the audit cleanup command.
        /// </summary>
        /// <param name="commandData">Provides access to Revit application and document.</param>
        /// <param name="message">Output message in case of failure.</param>
        /// <param name="elements">Elements set in case of failure.</param>
        /// <returns>
        /// Result.Succeeded if the command runs successfully, otherwise Result.Failed.
        /// </returns>
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uidoc = commandData.Application.ActiveUIDocument;
            Document doc = uidoc.Document;

            var flagged = new List<FlaggedItem>();

            // Scan for unused views
            flagged.AddRange(ViewScanner.GetUnusedViews(doc));

            // Scan for unused links
            flagged.AddRange(LinkScanner.GetUnusedLinks(doc));

            // Write log
            string logPath = Logger.WriteCsvLog(flagged);

            TaskDialog.Show("Model Audit & Cleanup",
                $"Flagged items: {flagged.Count}\nLog written:\n{logPath}");

            return Result.Succeeded;
        }
    }
}

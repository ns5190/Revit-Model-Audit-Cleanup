// -----------------------------------------------------------------------------
// File: ViewScanner.cs
// Purpose: Contains logic to scan Revit documents for unused views.
// -----------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;
using Autodesk.Revit.DB;

namespace RevitCleanup2025
{
    /// <summary>
    /// Provides methods to identify unused views in a Revit document.
    /// </summary>
    public static class ViewScanner
    {
        /// <summary>
        /// Scans the document for unused views.
        /// </summary>
        /// <param name="doc">The active Revit document.</param>
        /// <returns>
        /// A collection of FlaggedItem objects representing unused views.
        /// </returns>
        public static IEnumerable<FlaggedItem> GetUnusedViews(Document doc)
        {
            var results = new List<FlaggedItem>();

            var views = new FilteredElementCollector(doc)
                .OfClass(typeof(View))
                .Cast<View>()
                .Where(v => !v.IsTemplate);

            var placedViewIds = GetAllPlacedViewIds(doc);

            foreach (var v in views)
            {
                bool onSheet = placedViewIds.Contains(v.Id);

                if (!onSheet)
                {
                    results.Add(new FlaggedItem(
                        v.Id,
                        v.Name,
                        $"View ({v.ViewType})",
                        "Not placed on any sheet"
                    ));
                }
            }

            return results;
        }

        /// <summary>
        /// Collects all view IDs that are placed on sheets in the document.
        /// </summary>
        /// <param name="doc">The active Revit document.</param>
        /// <returns>
        /// A HashSet of ElementIds representing views placed on sheets.
        /// </returns>
        private static HashSet<ElementId> GetAllPlacedViewIds(Document doc)
        {
            var placed = new HashSet<ElementId>();
            var sheets = new FilteredElementCollector(doc)
                .OfClass(typeof(ViewSheet))
                .Cast<ViewSheet>();

            foreach (var sheet in sheets)
            {
                foreach (var viewId in sheet.GetAllPlacedViews())
                    placed.Add(viewId);
            }

            return placed;
        }
    }
}

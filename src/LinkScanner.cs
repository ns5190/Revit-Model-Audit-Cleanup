// -----------------------------------------------------------------------------
// File: LinkScanner.cs
// Purpose: Contains logic to scan Revit documents for unused Revit link instances.
// -----------------------------------------------------------------------------

using System.Collections.Generic;
using Autodesk.Revit.DB;

namespace RevitCleanup2025
{
    /// <summary>
    /// Provides methods to identify unused Revit links in a document.
    /// </summary>
    public static class LinkScanner
    {
        /// <summary>
        /// Scans the document for unused Revit links.
        /// </summary>
        /// <param name="doc">The active Revit document.</param>
        /// <returns>
        /// A collection of FlaggedItem objects representing unused links.
        /// </returns>
        public static IEnumerable<FlaggedItem> GetUnusedLinks(Document doc)
        {
            var results = new List<FlaggedItem>();

            var links = new FilteredElementCollector(doc)
                .OfClass(typeof(RevitLinkInstance))
                .Cast<RevitLinkInstance>();

            foreach (var link in links)
            {
                if (!link.IsLoaded)
                {
                    results.Add(new FlaggedItem(
                        link.Id,
                        link.Name,
                        "Revit Link",
                        "Unloaded"
                    ));
                }
            }

            return results;
        }
    }
}

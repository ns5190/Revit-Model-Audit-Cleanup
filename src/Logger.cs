// -----------------------------------------------------------------------------
// File: Logger.cs
// Purpose: Provides utility methods for writing flagged items to a CSV log file.
// -----------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.IO;

namespace RevitCleanup2025
{
    /// <summary>
    /// Utility class for logging flagged items to external files.
    /// </summary>
    public static class Logger
    {
        /// <summary>
        /// Writes a list of flagged items to a CSV log file.
        /// </summary>
        /// <param name="items">Collection of flagged items to log.</param>
        /// <param name="filePath">
        /// Optional path for the log file. If null, defaults to Desktop with timestamp.
        /// </param>
        /// <returns>
        /// The full path of the log file created.
        /// </returns>
        public static string WriteCsvLog(IEnumerable<FlaggedItem> items, string filePath = null)
        {
            string path = filePath ?? Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory),
                $"revit_cleanup_log_{DateTime.Now:yyyyMMdd_HHmmss}.csv");

            Directory.CreateDirectory(Path.GetDirectoryName(path)!);

            using (var sw = new StreamWriter(path))
            {
                sw.WriteLine("ID,Name,Category,Reason");
                foreach (var item in items)
                    sw.WriteLine(item.ToCsvRow());
            }

            return path;
        }
    }
}

// -----------------------------------------------------------------------------
// File: LoggerTests.cs
// Purpose: Unit tests for Logger utility.
// -----------------------------------------------------------------------------

using NUnit.Framework;
using System.IO;
using System.Collections.Generic;

namespace RevitCleanup2025.Tests
{
    [TestFixture]
    public class LoggerTests
    {
        /// <summary>
        /// Test that Logger writes a CSV file with correct headers and rows.
        /// </summary>
        [Test]
        public void WriteCsvLog_CreatesFileWithContent()
        {
            // Arrange
            var items = new List<FlaggedItem>
            {
                new FlaggedItem(new Autodesk.Revit.DB.ElementId(1), "Test View", "View", "Not placed on any sheet"),
                new FlaggedItem(new Autodesk.Revit.DB.ElementId(2), "Unloaded_Link_A.rvt", "Revit Link", "Unloaded")
            };

            string tempPath = Path.GetTempFileName();

            // Act
            string logPath = Logger.WriteCsvLog(items, tempPath);

            // Assert
            Assert.IsTrue(File.Exists(logPath));
            string[] lines = File.ReadAllLines(logPath);
            Assert.AreEqual("ID,Name,Category,Reason", lines[0]);
            Assert.IsTrue(lines[1].Contains("Test View"));
            Assert.IsTrue(lines[2].Contains("Unloaded_Link_A.rvt"));
        }
    }
}

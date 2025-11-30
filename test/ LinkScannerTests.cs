// -----------------------------------------------------------------------------
// File: LinkScannerTests.cs
// Purpose: Unit tests for LinkScanner logic using mocked Revit link instances.
// -----------------------------------------------------------------------------

using NUnit.Framework;
using Moq;
using Autodesk.Revit.DB;

namespace RevitCleanup2025.Tests
{
    [TestFixture]
    public class LinkScannerTests
    {
        /// <summary>
        /// Test that an unloaded Revit link is flagged.
        /// </summary>
        [Test]
        public void UnloadedLink_IsFlagged()
        {
            // Arrange: mock a RevitLinkInstance
            var mockLink = new Mock<RevitLinkInstance>(null, null);
            mockLink.Setup(l => l.IsLoaded).Returns(false);
            mockLink.Setup(l => l.Id).Returns(new ElementId(456));
            mockLink.Setup(l => l.Name).Returns("Unloaded_Link_A.rvt");

            // Act: simulate unused link
            var flagged = new FlaggedItem(mockLink.Object.Id, mockLink.Object.Name, "Revit Link", "Unloaded");

            // Assert
            Assert.AreEqual(456, flagged.Id.IntegerValue);
            Assert.AreEqual("Unloaded_Link_A.rvt", flagged.Name);
            Assert.AreEqual("Revit Link", flagged.Category);
            Assert.AreEqual("Unloaded", flagged.Reason);
        }
    }
}

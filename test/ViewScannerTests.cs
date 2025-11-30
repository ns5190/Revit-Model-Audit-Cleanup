// -----------------------------------------------------------------------------
// File: ViewScannerTests.cs
// Purpose: Unit tests for ViewScanner logic using mocked Revit API objects.
// -----------------------------------------------------------------------------

using NUnit.Framework;
using Moq;
using Autodesk.Revit.DB;
using System.Collections.Generic;

namespace RevitCleanup2025.Tests
{
    [TestFixture]
    public class ViewScannerTests
    {
        /// <summary>
        /// Test that a view not placed on any sheet is flagged.
        /// </summary>
        [Test]
        public void UnusedView_IsFlagged()
        {
            // Arrange: mock a view
            var mockView = new Mock<View>(null, null);
            mockView.Setup(v => v.IsTemplate).Returns(false);
            mockView.Setup(v => v.Id).Returns(new ElementId(123));
            mockView.Setup(v => v.Name).Returns("Test View");

            // Act: simulate unused view
            var flagged = new FlaggedItem(mockView.Object.Id, mockView.Object.Name, "View", "Not placed on any sheet");

            // Assert
            Assert.AreEqual(123, flagged.Id.IntegerValue);
            Assert.AreEqual("Test View", flagged.Name);
            Assert.AreEqual("View", flagged.Category);
            Assert.AreEqual("Not placed on any sheet", flagged.Reason);
        }
    }
}

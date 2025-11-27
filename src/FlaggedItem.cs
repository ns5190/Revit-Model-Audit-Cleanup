// -----------------------------------------------------------------------------
// File: FlaggedItem.cs
// Purpose: Defines a simple data structure to represent items flagged during
//          model audit (unused views, links, etc.). Provides CSV export support.
// -----------------------------------------------------------------------------

using Autodesk.Revit.DB;

namespace RevitCleanup2025
{
    /// <summary>
    /// Represents an element flagged during cleanup (e.g., unused view or link).
    /// Stores its ID, name, category, and reason for being flagged.
    /// </summary>
    public class FlaggedItem
    {
        /// <summary>
        /// The Revit element ID of the flagged item.
        /// </summary>
        public ElementId Id { get; }

        /// <summary>
        /// The human-readable name of the element.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// The category/type of the element (e.g., View, Revit Link).
        /// </summary>
        public string Category { get; }

        /// <summary>
        /// The reason why the element was flagged (e.g., "Not placed on sheet").
        /// </summary>
        public string Reason { get; }

        /// <summary>
        /// Constructor for FlaggedItem.
        /// </summary>
        /// <param name="id">Revit element ID of the flagged item.</param>
        /// <param name="name">Name of the element.</param>
        /// <param name="category">Category/type of the element.</param>
        /// <param name="reason">Reason why the element was flagged.</param>
        public FlaggedItem(ElementId id, string name, string category, string reason)
        {
            Id = id;
            Name = name ?? string.Empty;
            Category = category ?? string.Empty;
            Reason = reason ?? string.Empty;
        }

        /// <summary>
        /// Converts the flagged item into a CSV row string.
        /// </summary>
        /// <returns>A CSV-formatted string with ID, Name, Category, Reason.</returns>
        public string ToCsvRow()
        {
            return $"{Id.IntegerValue},\"{Name}\",\"{Category}\",\"{Reason}\"";
        }
    }
}

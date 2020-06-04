namespace ADL_Log_Data.Models
{
    using System;

    /// <summary>
    /// An activity record for a given day, for a given item, with an intensity/spoon scale entry
    /// </summary>
    public class JournalItem
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="JournalItem"/> class
        /// </summary>
        public JournalItem()
        {
            EntryDate = DateTime.UtcNow;
        }

        /// <summary>
        /// When did this happen
        /// </summary>
        /// <remarks>TODO: Localization should be considered here</remarks>
        public DateTime EntryDate { get; set; }

        /// <summary>
        /// Should eventually become an id if we are going to put these in tables
        /// </summary>
        /// <remarks>TODO: Ensure we store this in an easy to data-retrieve fashion</remarks>
        public ActivityItem Item { get; set; }

        /// <summary>
        /// Marks the severity of the Item's difficulty for that user that day
        /// </summary>
        public int Intensity { get; set; }

        public static JournalItem Create(ActivityItem item) {

            return new JournalItem() {
                Item = item
            };
        }
    }
}

/*
 * Examples include
Bathing - Shower
Bathing - Wash hair
Dressing - Finding clean clothes
Dressing - Putting on clothes
 */

namespace ADL_Log_Data.Models
{
    using Microsoft.VisualBasic;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// An activity record for a given day, for a given item, with an intensity/spoon scale entry
    /// </summary>
    public class JournalDay
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="JournalDay"/> class
        /// </summary>
        public JournalDay()
        {
        }

        /// <summary>
        /// When did this happen
        /// </summary>
        /// <remarks>TODO: Localization should be considered here</remarks>
        public DateTime EntryDate { get; set; }

        /// <summary>
        /// Show me all of today's activities
        /// </summary>
        /// <remarks>TODO: Ensure we store this in an easy to data-retrieve fashion</remarks>
        public List<JournalItem> Items { get; set; } = new List<JournalItem>();

        /// <summary>
        /// How did today fare overall?
        /// </summary>
        public int Intensity { get; set; }

        public static JournalDay Create() {
            var ret = new JournalDay();

            ret.Items.Add(new JournalItem());

            return ret;
        }

        public static JournalDay Create(List<JournalItem> items) {

            var ret = new JournalDay {
                Items = items
            };

            return ret;
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

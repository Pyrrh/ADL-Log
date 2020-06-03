namespace ADL_Log_Data.Models
{
    /// <summary>
    /// An activity item is a basic item for daily life activities. An example is brusing one's teeth, or dressing to go out, or bathing
    /// </summary>
    /// <remarks>
    /// One problem with this class is it does not let us store information per-user, as this is currently situated as a global list
    /// </remarks>
    public class ActivityItem
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ActivityItem"/> class.
        /// </summary>
        public ActivityItem()
        {
        }

        /// <summary>
        /// How we colloquially refer to the item
        /// </summary>
        /// <remarks>TODO: Localization should be considered here</remarks>
        public string Name { get; set; }

        /// <summary>
        /// Should eventually become an id if we are going to put these in tables
        /// </summary>
        /// <remarks>TODO: Ensure we store this in an easy to data-retrieve fashion</remarks>
        public ActivityItemClass Class { get; set; }
    }
}

/*
 * Examples include
Bathing - Shower
Bathing - Wash hair
Dressing - Finding clean clothes
Dressing - Putting on clothes
 */

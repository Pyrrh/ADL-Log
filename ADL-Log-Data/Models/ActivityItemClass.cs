namespace ADL_Log_Data.Models
{
    /// <summary>
    /// An actiivty item class is a way to group activity items
    /// </summary>
    public class ActivityItemClass
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ActivityItemClass"/> class.
        /// </summary>
        public ActivityItemClass()
        {
        }

        /// <summary>
        /// How we colloquially refer to the item set
        /// </summary>
        /// <remarks>TODO: Localization should be considered here</remarks>
        public string Name { get; set; }
    }
}
/*
 * Examples include
Bathing
Dressing
Grooming
Oral Care
Toileting
Transferring
Walking
Climbing Stairs
Eating
Shopping
Cooking
Managing Medications
Uses the Phone
Housework
Laundry
Driving
Managing Finances
Totals
 */

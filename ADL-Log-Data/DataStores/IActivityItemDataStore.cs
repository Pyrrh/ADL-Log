namespace ADL_Log_Data.DataStores
{
    using System.Collections.Generic;
    using ADL_Log_Data.Models;

    /// <summary>
    /// Used to store information about ActivityItems
    /// </summary>
    public interface IActivityItemDataStore
    {
        /// <summary>
        /// Get all activity items in the system
        /// </summary>
        /// <param name="name">A specific name to find the activity item by</param>
        /// <returns>ActivityItem as specified by the name</returns>
        ActivityItem GetActivityItem(string name);

        /// <summary>
        /// Get all activity items in the system
        /// </summary>
        /// <returns>All ActivityItem</returns>
        IList<ActivityItem> GetActivityItems();

        /// <summary>
        /// Get all activity classes in the system
        /// </summary>
        /// <param name="name">A specific name to find the activity item class by</param>
        /// <returns>All ActivityItemClass</returns>
        IList<ActivityItemClass> GetActivityItemClass(string name);

        /// <summary>
        /// Get all activity classes in the system
        /// </summary>
        /// <returns>All ActivityItemClass</returns>
        IList<ActivityItemClass> GetActivityItemClasses();
    }
}

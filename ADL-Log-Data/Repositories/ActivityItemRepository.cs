namespace ADL_Log_Data.Repositories
{
    using ADL_Log_Data.DataStores;
    using ADL_Log_Data.Models;
    using System.Collections.Generic;

    /// <summary>
    /// Use this to fetch ActivityItem records
    /// </summary>
    public class ActivityItemRepository : IActivityItemRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ActivityItemRepository"/> class.
        /// </summary>
        public ActivityItemRepository(IActivityItemDataStore activityItemDataStore)
        {
            ActivityItemDataStore = activityItemDataStore ?? throw new System.ArgumentNullException(nameof(activityItemDataStore));
        }

        /// <summary>
        /// Used to retrieve activity items
        /// </summary>
        public IActivityItemDataStore ActivityItemDataStore { get; }

        /// <inheritdoc/>
        public ActivityItem GetActivityItem(string name)
        {
            throw new System.NotImplementedException();
        }

        public IList<ActivityItemClass> GetActivityItemClass(string name)
        {
            throw new System.NotImplementedException();
        }

        public IList<ActivityItemClass> GetActivityItemClasses()
        {
            throw new System.NotImplementedException();
        }

        public IList<ActivityItem> GetActivityItems()
        {
            throw new System.NotImplementedException();
        }
    }
}

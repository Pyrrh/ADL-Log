namespace ADL_Log_Data.Repositories
{
    using ADL_Log_Data.DataStores;

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
    }
}

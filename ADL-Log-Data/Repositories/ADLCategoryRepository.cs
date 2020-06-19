namespace ADL_Log_Data.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using ADL_Log_Data.DataStores;
    using ADL_Log_Data.Models;
    using Microsoft.Extensions.Logging;

    /// <summary>
    /// Used to talk to the appropriate data store(s)
    /// </summary>
    public class ADLCategoryRepository : IADLCategoryRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ADLCategoryRepository"/> class.
        /// </summary>
        /// <param name="logger">a default logger implementation</param>
        /// <param name="adlCategoryDataStore">some category data store</param>
        public ADLCategoryRepository(ILogger<ADLCategoryRepository> logger, IADLCategoryDataStore adlCategoryDataStore)
        {
            this.Logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.ADLCategoryDataStore = adlCategoryDataStore ?? throw new ArgumentNullException(nameof(adlCategoryDataStore));
        }

        /// <summary>
        /// Basic logger
        /// </summary>
        public ILogger<ADLCategoryRepository> Logger { get; }

        /// <summary>
        /// ADLCategory data store
        /// </summary>
        public IADLCategoryDataStore ADLCategoryDataStore { get; }

        /// <inheritdoc/>
        public async Task<ADLCategory> Get(string name)
        {
            return await this.ADLCategoryDataStore.Get(name);
        }

        /// <inheritdoc/>
        public async Task<IList<ADLCategory>> Get(IList<string> names)
        {
            return await this.ADLCategoryDataStore.Get(names);
        }

        /// <inheritdoc/>
        public async Task<IList<ADLCategory>> GetCategories()
        {
            return await this.ADLCategoryDataStore.GetCategories();
        }

        /// <inheritdoc/>
        public async Task<IList<string>> GetCategoryNames()
        {
            return await this.ADLCategoryDataStore.GetCategoryNames();
        }

        /// <inheritdoc/>
        public async Task<IList<ADLCategoryTask>> GetTasks(string name)
        {
            return await this.ADLCategoryDataStore.GetTasks(name);
        }

        /// <inheritdoc/>
        public async Task<ADLCategory> Update(ADLCategory category)
        {
            return await this.ADLCategoryDataStore.Update(category);
        }
    }
}

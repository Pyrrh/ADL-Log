namespace ADL_Log_Data.DataStores
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using ADL_Log_Data.Models;

    /// <summary>
    /// Used to store information about ActivityItems
    /// </summary>
    public interface IADLCategoryDataStore
    {
        /// <summary>
        /// Get the complete list of ADLCategories
        /// </summary>
        /// <returns>The simple class names</returns>
        Task<IList<string>> GetCategoryNames();

        /// <summary>
        /// Get the complete list of ADLCategories
        /// </summary>
        /// <returns>All ActivityItemClass</returns>
        Task<IList<ADLCategory>> GetCategories();

        /// <summary>
        /// Get an ADLCategory by a specific name
        /// </summary>
        /// <param name="name">The name of the category</param>
        /// <returns>A simple ADLCategory</returns>
        Task<ADLCategory> Get(string name);

        /// <summary>
        /// Get many ADLCategorys by names
        /// </summary>
        /// <param name="names">The several categories to retrieve</param>
        /// <returns>A set of categories</returns>
        Task<IList<ADLCategory>> Get(IList<string> names);

        /// <summary>
        /// Get all tasks for a specific category
        /// </summary>
        /// <param name="name">A specific name to find the category by</param>
        /// <returns>All related task objects</returns>
        Task<IList<ADLCategoryTask>> GetTasks(string name);
    }
}

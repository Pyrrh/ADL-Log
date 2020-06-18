namespace ADL_Log_Data.Models
{
    using System.Collections.Generic;

    /// <summary>
    /// This is a simple grouping mechanism to help people find tasks more quickly
    /// </summary>
    public class ADLCategory
    {
        /// <summary>
        /// A simple name to refer to the category by
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// A collection of tasks for what we can do in a category
        /// </summary>
        public IList<ADLCategoryTask> Tasks { get; set; } = new List<ADLCategoryTask>();
    }
}

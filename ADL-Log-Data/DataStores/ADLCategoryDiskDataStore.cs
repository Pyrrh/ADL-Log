namespace ADL_Log_Data.DataStores
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using ADL_Log_Data.Models;
    using Microsoft.Extensions.Logging;
    using StackExchange.Profiling;

    /// <summary>
    /// Used to store information about ActivityItems
    /// </summary>
    public class ADLCategoryDiskDataStore : IADLCategoryDataStore
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ADLCategoryDiskDataStore"/> class.
        /// </summary>
        /// <param name="logger">The default logging extension</param>
        public ADLCategoryDiskDataStore(ILogger<ADLCategoryDiskDataStore> logger)
        {
            this.Logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        private ILogger<ADLCategoryDiskDataStore> Logger { get; }

        /// <inheritdoc/>
        public async Task<IList<string>> GetCategoryNames()
        {
            using (MiniProfiler.Current.Step("Get all category names"))
            {
                this.Logger.LogTrace("Get all category names");
                return await this.GetFileNames();
            }
        }

        /// <inheritdoc/>
        public async Task<IList<ADLCategory>> GetCategories()
        {
            using (MiniProfiler.Current.Step("Get all categories"))
            {
                this.Logger.LogTrace("Get all categories");
                return (await this.GetFileContents(null)).ToArray();
            }
        }

        /// <inheritdoc/>
        public async Task<ADLCategory> Get(string name)
        {
            using (MiniProfiler.Current.Step($"Get category by name [{name}]"))
            {
                if (string.IsNullOrEmpty(name))
                {
                    throw new ArgumentException("The category name must be provided", "name");
                }

                var result = (await this.GetFileContents(name)).FirstOrDefault();

                if (result == null)
                {
                    this.Logger.LogTrace($"Could not find the filename/category specified {name}");
                    throw new ArgumentOutOfRangeException("name", "The category name could not be found");
                }

                return result;
            }
        }

        /// <inheritdoc/>
        public async Task<IList<ADLCategory>> Get(IList<string> names)
        {
            if (names == null || names.Count == 0)
            {
                throw new ArgumentException("One or more category names must be provided", "names");
            }

            using (MiniProfiler.Current.Step($"Get category by name [{string.Join(",", names)}]"))
            {
                var result = new List<ADLCategory>();

                foreach (var name in names)
                {
                    var inlineResult = (await this.GetFileContents(name)).FirstOrDefault();

                    if (inlineResult == null)
                    {
                        this.Logger.LogTrace($"Could not find the filename/category specified {name}");
                        throw new ArgumentOutOfRangeException("name", "The category name could not be found");
                    }

                    result.Add(inlineResult);
                }

                return result;
            }
        }

        /// <inheritdoc/>
        public async Task<IList<ADLCategoryTask>> GetTasks(string name)
        {
            using (MiniProfiler.Current.Step($"Get category by name [{name}]"))
            {
                if (string.IsNullOrEmpty(name))
                {
                    throw new ArgumentException("The category name must be provided", "name");
                }

                var result = (await this.GetFileContents(name)).FirstOrDefault();

                if (result == null)
                {
                    this.Logger.LogTrace($"Could not find the filename/category specified {name}");
                    throw new ArgumentOutOfRangeException("name", "The category name could not be found");
                }

                return result.Tasks;
            }
        }

        /// <inheritdoc/>
        public Task<ADLCategory> Update(ADLCategory category)
        {
            throw new NotImplementedException();
        }

        private async Task<IList<ADLCategory>> GetFileContents(string name)
        {
            return (await this.GetFilePaths())
                .Where(x => string.IsNullOrWhiteSpace(name) || Path.GetFileNameWithoutExtension(x.Name).ToLower() == name.ToLower())
                .Select(x => Jil.JSON.Deserialize<ADLCategory>(File.ReadAllText(x.FullName)))
                .ToArray();
        }

        private async Task<IList<string>> GetFileNames()
        {
            return (await this.GetFilePaths()).Select(x => Path.GetFileNameWithoutExtension(x.Name)).ToArray();
        }

#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        private async Task<IList<FileInfo>> GetFilePaths()
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            // Look for the place where the files are located
            // TODO: Make this configurable
            var directoryInfo = new DirectoryInfo(Directory.GetCurrentDirectory());

            while (directoryInfo.Parent != null && !directoryInfo.EnumerateDirectories("jsons").Any())
            {
                this.Logger.LogTrace($"Couldn't find json files, checking the parent folder for {directoryInfo.FullName} -> {directoryInfo.Parent}");
                directoryInfo = directoryInfo.Parent;
            }

            if (directoryInfo.Parent == null)
            {
                this.Logger.LogTrace("I couldn't find a json folder to read from. Sad panda.");
                throw new Exception("No files found to look at for data");
            }

            return directoryInfo.EnumerateFiles("*.json", SearchOption.AllDirectories).ToArray();
        }
    }
}
namespace ADL_Log_Web.Controllers
{
    using System.Diagnostics;
    using ADL_Log_Data.Repositories;
    using ADL_Log_Web.Models;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;

    /// <summary>
    /// The basic/default controller
    /// </summary>
    public class HomeController : Controller
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HomeController"/> class.
        /// </summary>
        /// <param name="logger">A simple logger element</param>
        public HomeController(ILogger<HomeController> logger, IActivityItemRepository activityItemRepository)
        {
            Logger = logger ?? throw new System.ArgumentNullException(nameof(logger));
            ActivityItemRepository = activityItemRepository ?? throw new System.ArgumentNullException(nameof(activityItemRepository));
        }

        /// <summary>
        /// Used to log basic information using a generic and simple pattern
        /// </summary>
        private ILogger<HomeController> Logger { get; }

        /// <summary>
        /// Used to get some activities
        /// </summary>
        private IActivityItemRepository ActivityItemRepository { get; }

        /// <summary>
        /// Render a basic view
        /// </summary>
        /// <returns>A rendered view</returns>
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Render a basic privacy page
        /// </summary>
        /// <returns>A rendered view</returns>
        public IActionResult Privacy()
        {
            return View();
        }

        /// <summary>
        /// Render a basic error page
        /// </summary>
        /// <returns>A rendered view</returns>
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

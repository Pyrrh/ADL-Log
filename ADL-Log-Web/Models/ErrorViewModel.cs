namespace ADL_Log_Web.Models
{
    /// <summary>
    /// Used for displaying errors using the default error handler
    /// </summary>
    public class ErrorViewModel
    {
        /// <summary>
        /// The request id that failed
        /// </summary>
        public string RequestId { get; set; }

        /// <summary>
        /// Should we show the request id on the page
        /// </summary>
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}

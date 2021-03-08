namespace DocJur.Api.App.Models.Responses
{
    /// <summary>
    /// Basic response structure.
    /// </summary>
    public class BasicResponse
    {
        /// <summary>
        /// True if it was successful, false otherwise.
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// Error or information message.
        /// </summary>
        public string Message { get; set; }
    }
}

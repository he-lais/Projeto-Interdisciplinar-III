using System;

namespace DocJur.Api.App.Utilities
{
    /// <summary>
    /// Extended container to handle exceptions in this application with custom logic.
    /// </summary>
    public class DocJurException : Exception
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="message">Error Message.</param>
        public DocJurException(string message) : base(message) { }
    }
}

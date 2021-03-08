namespace DocJur.Api.App.Models
{
    /// <summary>
    /// Type of document
    /// </summary>
    public class DocumentType : AppModel
    {
        /// <summary>
        /// Name that identifies the DocumentType.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Default content of the DocumentType
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        public DocumentType() : base() { }
    }
}

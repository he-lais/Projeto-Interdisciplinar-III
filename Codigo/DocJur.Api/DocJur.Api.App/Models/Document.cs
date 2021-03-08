namespace DocJur.Api.App.Models
{
    /// <summary>
    /// Representation of Document entity.
    /// </summary>
    public class Document : AppModel
    {
        /// <summary>
        /// Raw content of the document after it was generated.
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// User that created the document.
        /// </summary>
        public User User { get; set; }

        /// <summary>
        /// Document type of the Document.
        /// </summary>
        public DocumentType DocumentType { get; set; }

        public Document() { }

        /// <summary>
        /// Constructor.
        /// </summary>
        public Document(DocumentType documentType, User user) : this()
        {
            DocumentType = documentType;
            Content = documentType.Content;
            User = user;
        }
    }
}
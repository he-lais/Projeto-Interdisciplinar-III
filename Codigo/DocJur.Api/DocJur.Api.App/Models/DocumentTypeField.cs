using DocJur.Api.App.Models.Enums;

namespace DocJur.Api.App.Models
{
    /// <summary>
    /// Representation of DocumentTypeField entity.
    /// </summary>
    public class DocumentTypeField : AppModel
    {
        /// <summary>
        /// Label of the field that will appear on the component.
        /// </summary>
        public string Label { get; set; }

        /// <summary>
        /// Name of the field.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Type of document.
        /// </summary>
        public DocumentType DocumentType { get; set; }

        /// <summary>
        /// Type of field.
        /// </summary>
        public FieldType FieldType { get; set; }
    }
}

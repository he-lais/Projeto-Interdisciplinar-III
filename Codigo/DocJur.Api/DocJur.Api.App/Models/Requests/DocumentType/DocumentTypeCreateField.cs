using DocJur.Api.App.Models.Enums;

namespace DocJur.Api.App.Models.Requests.DocumentType
{
    public class DocumentTypeCreateField
    {
        public string Label { get; set; }
        public string Name { get; set; }
        public FieldType FieldType { get; set; }
    }
}
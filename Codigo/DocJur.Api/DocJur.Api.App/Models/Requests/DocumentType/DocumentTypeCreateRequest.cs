using System.Collections.Generic;

namespace DocJur.Api.App.Models.Requests.DocumentType
{
    public class DocumentTypeCreateRequest
    {
        public string Name { get; set; }
        public string Content { get; set; }
        public IList<DocumentTypeCreateField> Fields { get; set; }
    }
}
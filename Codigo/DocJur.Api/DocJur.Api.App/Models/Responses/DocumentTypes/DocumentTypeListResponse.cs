using System.Collections.Generic;

namespace DocJur.Api.App.Models.Responses.DocumentTypes
{
    public class DocumentTypeListResponse : BasicResponse
    {
        public IList<DocumentType> DocumentTypes { get; set; }
    }
}

using System.Collections.Generic;

namespace DocJur.Api.App.Models.Responses.DocumentTypeFields
{
    public class DocumentTypeFieldListResponse : BasicResponse
    {
        public IList<DocumentTypeField> Fields { get; set; }
    }
}

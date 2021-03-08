using System.Collections.Generic;

namespace DocJur.Api.App.Models.Responses.Documents
{
    public class DocumentListResponse : BasicResponse
    {
        public IList<DocumentListItem> Documents { get; set; }
    }
}

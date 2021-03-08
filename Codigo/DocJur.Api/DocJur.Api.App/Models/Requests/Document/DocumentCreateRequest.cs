using System;
using System.Collections.Generic;

namespace DocJur.Api.App.Models.Requests.Document
{
    public class DocumentCreateRequest
    {
        public Guid DocumentTypeId { get; set; }
        public Guid UserId { get; set; }
        public IList<DocumentCreateField> Fields { get; set; }
    }
}

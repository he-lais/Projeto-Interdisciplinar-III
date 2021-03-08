using System;

namespace DocJur.Api.App.Models.Responses.Documents
{
    public class DocumentListItem
    {
        public Guid Id { get; set; }

        public string UserName { get; set; }

        public string DocumentTypeName { get; set; }

        public DocumentListItem(Document document)
        {
            Id = document.Id;
            UserName = document.User?.Username;
            DocumentTypeName = document.DocumentType.Name;
        }
    }
}

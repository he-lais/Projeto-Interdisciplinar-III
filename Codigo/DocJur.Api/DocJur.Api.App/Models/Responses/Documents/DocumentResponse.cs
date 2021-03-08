namespace DocJur.Api.App.Models.Responses.Documents
{
    public class DocumentResponse : BasicResponse
    {
        public Document Document { get; set; }

        public DocumentResponse() : base() { }
    }
}

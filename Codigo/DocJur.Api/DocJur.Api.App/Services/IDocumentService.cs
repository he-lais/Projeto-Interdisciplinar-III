using DocJur.Api.App.Models.Requests.Document;
using DocJur.Api.App.Models.Responses;
using DocJur.Api.App.Models.Responses.Documents;

namespace DocJur.Api.App.Services
{
    public interface IDocumentService
    {
        BasicResponse Create(DocumentCreateRequest request);
        DocumentResponse GetDocument(DocumentIdRequest documentIdRequest);
        DocumentListResponse FindAll();
        BasicResponse DeleteDocument(DocumentIdRequest documentIdRequest);
        BasicResponse DeleteAll();
    }
}

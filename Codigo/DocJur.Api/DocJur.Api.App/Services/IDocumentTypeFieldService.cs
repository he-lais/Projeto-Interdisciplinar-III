using DocJur.Api.App.Models.Requests;
using DocJur.Api.App.Models.Responses.DocumentTypeFields;

namespace DocJur.Api.App.Services
{
    public interface IDocumentTypeFieldService
    {
        DocumentTypeFieldListResponse FindByDocumentType(IdRequest request);
    }
}

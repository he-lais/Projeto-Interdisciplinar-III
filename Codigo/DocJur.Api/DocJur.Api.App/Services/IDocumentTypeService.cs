using DocJur.Api.App.Models.Requests.DocumentType;
using DocJur.Api.App.Models.Responses;
using DocJur.Api.App.Models.Responses.DocumentTypes;
using System;

namespace DocJur.Api.App.Services
{
    public interface IDocumentTypeService
    {
        DocumentTypeResponse Find(Guid id);
        DocumentTypeListResponse FindAll();
        BasicResponse Create(DocumentTypeCreateRequest request);
    }
}

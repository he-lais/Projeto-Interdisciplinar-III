using DocJur.Api.App.Models.Requests;
using DocJur.Api.App.Models.Responses.DocumentTypeFields;
using DocJur.Api.App.Services;
using Microsoft.AspNetCore.Mvc;

namespace DocJur.Api.App.Controllers
{
    public class DocumentTypeFieldController : Controller
    {
        private IDocumentTypeFieldService DocumentTypeFieldService { get; }

        public ActionResult<DocumentTypeFieldListResponse> List([FromBody] IdRequest request) => DocumentTypeFieldService.FindByDocumentType(request);

        public DocumentTypeFieldController(IDocumentTypeFieldService documentTypeFieldService) => DocumentTypeFieldService = documentTypeFieldService;
    }
}

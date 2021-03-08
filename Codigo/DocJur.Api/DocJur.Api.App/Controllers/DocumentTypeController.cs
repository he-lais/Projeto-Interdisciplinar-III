using DocJur.Api.App.Models.Requests.DocumentType;
using DocJur.Api.App.Models.Responses;
using DocJur.Api.App.Models.Responses.DocumentTypes;
using DocJur.Api.App.Services;
using Microsoft.AspNetCore.Mvc;

namespace DocJur.Api.App.Controllers
{
    public class DocumentTypeController : Controller
    {
        private IDocumentTypeService DocumentTypeService { get; set; }

        public DocumentTypeController(IDocumentTypeService documentTypeService) => DocumentTypeService = documentTypeService;

        public ActionResult<DocumentTypeListResponse> List() => DocumentTypeService.FindAll();

        [HttpPost]
        public ActionResult<BasicResponse> Create([FromBody] DocumentTypeCreateRequest request) => DocumentTypeService.Create(request);
    }
}
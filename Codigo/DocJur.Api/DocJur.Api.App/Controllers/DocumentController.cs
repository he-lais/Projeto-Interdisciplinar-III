using DocJur.Api.App.Models.Requests.Document;
using DocJur.Api.App.Models.Responses;
using DocJur.Api.App.Models.Responses.Documents;
using DocJur.Api.App.Services;
using Microsoft.AspNetCore.Mvc;

namespace DocJur.Api.App.Controllers
{
    /// <summary>
    /// Controller for Document related requests.
    /// </summary>
    public class DocumentController : Controller
    {
        private IDocumentService DocumentService { get; }

        [HttpPost]
        public ActionResult<BasicResponse> Create([FromBody] DocumentCreateRequest request) => DocumentService.Create(request);

        [HttpPost]
        public ActionResult<DocumentResponse> Details([FromBody] DocumentIdRequest documentIdRequest) => DocumentService.GetDocument(documentIdRequest);
        public ActionResult<DocumentListResponse> List() => DocumentService.FindAll();

        [HttpPost]
        public ActionResult<BasicResponse> Delete([FromBody] DocumentIdRequest documentIdRequest) => DocumentService.DeleteDocument(documentIdRequest);
        public ActionResult<BasicResponse> DeleteAll() => DocumentService.DeleteAll();

        public DocumentController(IDocumentService documentService) => DocumentService = documentService;


    }
}
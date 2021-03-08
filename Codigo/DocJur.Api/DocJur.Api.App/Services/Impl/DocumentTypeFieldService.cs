using DocJur.Api.App.Models;
using DocJur.Api.App.Models.Requests;
using DocJur.Api.App.Models.Responses.DocumentTypeFields;
using DocJur.Api.App.Repository;
using DocJur.Api.App.Utilities;
using System;
using System.Collections.Generic;

namespace DocJur.Api.App.Services.Impl
{
    public class DocumentTypeFieldService : IDocumentTypeFieldService
    {
        private IDocumentTypeFieldRepository DocumentTypeFieldRepository { get; }

        public DocumentTypeFieldListResponse FindByDocumentType(IdRequest request)
        {
            try
            {
                IList<DocumentTypeField> fields = DocumentTypeFieldRepository.FindByDocumentType(request.Id);

                if (fields.IsEmpty())
                {
                    throw new DocJurException("Nenhum campo encontrado.");
                }

                return new DocumentTypeFieldListResponse { Success = true, Message = string.Empty, Fields = fields };
            }
            catch (Exception e)
            {
                return new DocumentTypeFieldListResponse { Success = false, Message = e.Message };
            }
        }

        public DocumentTypeFieldService(IDocumentTypeFieldRepository documentTypeFieldRepository) => DocumentTypeFieldRepository = documentTypeFieldRepository;
    }
}

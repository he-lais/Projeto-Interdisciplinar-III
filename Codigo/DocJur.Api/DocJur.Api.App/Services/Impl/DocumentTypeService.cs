using DocJur.Api.App.Models;
using DocJur.Api.App.Models.Requests.DocumentType;
using DocJur.Api.App.Models.Responses;
using DocJur.Api.App.Models.Responses.DocumentTypes;
using DocJur.Api.App.Repository;
using DocJur.Api.App.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DocJur.Api.App.Services.Impl
{
    public class DocumentTypeService : IDocumentTypeService
    {
        private IDocumentTypeRepository DocumentTypeRepository { get; }
        private IDocumentTypeFieldRepository DocumentTypeFieldRepository { get; }

        public DocumentTypeService(IDocumentTypeRepository documentTypeRepository, IDocumentTypeFieldRepository documentTypeFieldRepository)
        {
            DocumentTypeRepository = documentTypeRepository;
            DocumentTypeFieldRepository = documentTypeFieldRepository;
        }

        public DocumentTypeResponse Find(Guid id)
        {
            DocumentType documentType = DocumentTypeRepository.Find(id);

            if (documentType == null)
            {
                return new DocumentTypeResponse { Success = false, Message = "Modelo não encontrado" };
            }

            DocumentTypeResponse documentTypeResponse = new DocumentTypeResponse
            {
                Message = "Modelo encontrado com sucesso",
                Success = true,
                DocumentType = documentType
            };

            return documentTypeResponse;
        }

        public DocumentTypeListResponse FindAll()
        {
            DocumentTypeListResponse documentTypeListResponse = new DocumentTypeListResponse();

            IList<DocumentType> documentTypes = DocumentTypeRepository.FindAll().OrderBy(dt => dt.Name).ToList();

            if (documentTypes.IsEmpty())
            {
                documentTypeListResponse.Message = "Nenhum modelo encontrado";
                documentTypeListResponse.Success = false;

                return documentTypeListResponse;
            }

            documentTypeListResponse.Message = "Modelos encontrados com sucesso";
            documentTypeListResponse.Success = true;
            documentTypeListResponse.DocumentTypes = documentTypes;

            return documentTypeListResponse;
        }

        /// <summary>
        /// Create a new DocumentType.
        /// </summary>
        /// <param name="request">request information.</param>
        public BasicResponse Create(DocumentTypeCreateRequest request)
        {
            try
            {
                if (request == null)
                {
                    throw new DocJurException("Dados de request foram enviadas no formato incorreto.");
                }
                DocumentType documentType = new DocumentType
                {
                    Name = request.Name,
                    Content = request.Content
                };

                DocumentTypeRepository.Add(documentType);

                request.Fields.ForEach(field =>
                {
                    DocumentTypeField documentTypeField = new DocumentTypeField
                    {
                        Name = field.Name,
                        Label = field.Label,
                        DocumentType = documentType,
                        FieldType = field.FieldType
                    };

                    DocumentTypeFieldRepository.Add(documentTypeField);
                });

                return new BasicResponse { Success = true, Message = "Modelo criado com sucesso." };
            }
            catch (Exception e)
            {
                return new BasicResponse { Success = false, Message = e.Message };
            }
        }
    }
}

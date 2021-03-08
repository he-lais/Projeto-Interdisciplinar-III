using DocJur.Api.App.Models;
using DocJur.Api.App.Models.Requests.Document;
using DocJur.Api.App.Models.Responses;
using DocJur.Api.App.Models.Responses.Documents;
using DocJur.Api.App.Repository;
using DocJur.Api.App.Utilities;
using System;
using System.Collections.Generic;

namespace DocJur.Api.App.Services.Impl
{
    public class DocumentService : IDocumentService
    {
        private IDocumentTypeRepository DocumentTypeRepository { get; }
        private IUserRepository UserRepository { get; }
        private IDocumentRepository DocumentRepository { get; }

        public BasicResponse Create(DocumentCreateRequest request)
        {
            try
            {
                DocumentType documentType = DocumentTypeRepository.Find(request.DocumentTypeId);
                User user = UserRepository.Find(request.UserId);

                if (documentType == null)
                {
                    return new BasicResponse { Success = false, Message = $"Nenhum tipo de documento encontrado para o Id {request.DocumentTypeId}" };
                }
                if (user == null)
                {
                    return new BasicResponse { Success = false, Message = $"Nenhum usuário encontrado para o Id {request.DocumentTypeId}" };
                }

                Document document = new Document(documentType, user);
                request.Fields.ForEach(field =>
                {
                    document.Content = document.Content = document.Content.Replace($"[{field.Name}]", field.Value);
                });
                DocumentRepository.Add(document);

                return new BasicResponse { Success = true, Message = "Documento criado com sucesso." };
            }
            catch (Exception e)
            {
                return new BasicResponse { Success = false, Message = $"Erro inesperado: {e.Message}" };
            }
        }

        public DocumentResponse GetDocument(DocumentIdRequest documentIdRequest)
        {
            Document document = DocumentRepository.Find(documentIdRequest.DocumentId);

            if (document == null)
            {
                return new DocumentResponse { Success = false, Message = "Documento não encontrado" };
            }

            DocumentResponse documentResponse = new DocumentResponse
            {
                Message = "Documento encontrado com sucesso",
                Success = true,
                Document = document
            };

            return documentResponse;
        }

        public DocumentListResponse FindAll()
        {
            try
            {
                IList<Document> documents = DocumentRepository.FindAll();
                IList<DocumentListItem> documentItems = new List<DocumentListItem>();
                documents.ForEach(d => documentItems.Add(new DocumentListItem(d)));
                return new DocumentListResponse { Success = true, Message = string.Empty, Documents = documentItems };
            }
            catch (Exception e)
            {
                return new DocumentListResponse { Success = false, Message = e.Message };
            }
        }

        public BasicResponse DeleteDocument(DocumentIdRequest documentIdRequest)
        {
            try
            {
                DocumentRepository.Delete(documentIdRequest.DocumentId);
                return new BasicResponse { Success = true, Message = "Documento removido com sucesso." };
            }
            catch (Exception e)
            {
                return new BasicResponse { Success = false, Message = e.Message };
            }
        }

        public BasicResponse DeleteAll()
        {
            try
            {
                DocumentRepository.DeleteAll();
                return new BasicResponse { Success = true, Message = "Histórico de documentos foi limpo com sucesso." };
            }
            catch (Exception e)
            {
                return new BasicResponse { Success = false, Message = e.Message };
            }
        }

        public DocumentService(IDocumentTypeRepository documentTypeRepository, IUserRepository userRepository, IDocumentRepository documentRepository)
        {
            DocumentTypeRepository = documentTypeRepository;
            UserRepository = userRepository;
            DocumentRepository = documentRepository;
        }
    }

}

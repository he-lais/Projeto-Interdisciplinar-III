using DocJur.Api.App.Database;
using DocJur.Api.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DocJur.Api.App.Repository.Impl
{
    public class DocumentTypeFieldRepository : IDocumentTypeFieldRepository
    {
        private DatabaseContext DatabaseContext { get; set; }

        public void Add(DocumentTypeField documentTypeField)
        {
            DatabaseContext.DocumentTypeFields.Add(documentTypeField);
            DatabaseContext.SaveChanges();
        }

        public IList<DocumentTypeField> FindByDocumentType(Guid id) => DatabaseContext.DocumentTypeFields.Where(f => f.DocumentType.Id == id).ToList();

        public DocumentTypeFieldRepository(DatabaseContext databaseContext) => DatabaseContext = databaseContext;
    }
}

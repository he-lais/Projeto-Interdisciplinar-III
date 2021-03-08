using DocJur.Api.App.Database;
using DocJur.Api.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DocJur.Api.App.Repository.Impl
{
    public class DocumentTypeRepository : IDocumentTypeRepository
    {
        private DatabaseContext DatabaseContext { get; set; }

        public DocumentTypeRepository(DatabaseContext databaseContext)
        {
            DatabaseContext = databaseContext;
        }

        public DocumentType Find(Guid id) => DatabaseContext.DocumentTypes.Find(id);

        public IList<DocumentType> FindAll() => DatabaseContext.DocumentTypes.ToList();

        public void Add(DocumentType documentType)
        {
            DatabaseContext.DocumentTypes.Add(documentType);
            DatabaseContext.SaveChanges();
        }

    }
}

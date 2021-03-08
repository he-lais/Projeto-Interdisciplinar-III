using DocJur.Api.App.Database;
using DocJur.Api.App.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DocJur.Api.App.Repository.Impl
{
    public class DocumentRepository : IDocumentRepository
    {
        private DatabaseContext DatabaseContext { get; set; }

        public void Add(Document document)
        {
            DatabaseContext.Documents.Add(document);
            DatabaseContext.SaveChanges();
        }

        public Document Find(Guid id)
        {
            return DatabaseContext.Documents.Find(id);
        }

        public IList<Document> FindAll()
        {
            return DatabaseContext.Documents.Include(d => d.DocumentType).Include(d => d.User).ToList();
        }

        public void Delete(Guid documentId)
        {
            Document document = DatabaseContext.Documents.FirstOrDefault(d => d.Id == documentId);
            DatabaseContext.Documents.Remove(document);
            DatabaseContext.SaveChanges();
        }

        public void DeleteAll()
        {
            DatabaseContext.Documents.RemoveRange(DatabaseContext.Documents);
            DatabaseContext.SaveChanges();
        }

        public DocumentRepository(DatabaseContext databaseContext) => DatabaseContext = databaseContext;
    }
}

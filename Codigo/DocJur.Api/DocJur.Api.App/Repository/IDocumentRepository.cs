using DocJur.Api.App.Models;
using System;
using System.Collections.Generic;

namespace DocJur.Api.App.Repository
{
    public interface IDocumentRepository
    {
        void Add(Document document);

        /// <summary>
        /// Find one Document by the Id
        /// </summary>
        /// <param name="id">Document Id</param>
        /// <returns>Document</returns>
        Document Find(Guid id);

        IList<Document> FindAll();
        void Delete(Guid documentId);

        void DeleteAll();
    }
}

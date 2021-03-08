using DocJur.Api.App.Models;
using System;
using System.Collections.Generic;

namespace DocJur.Api.App.Repository
{
    /// <summary>
    /// Repository to manage entities from  table.
    /// </summary>
    public interface IDocumentTypeRepository
    {
        /// <summary>
        /// Find one DocumentType by the Id
        /// </summary>
        /// <param name="id">DocumentType Id</param>
        /// <returns>DocumentType</returns>
        DocumentType Find(Guid id);

        /// <summary>
        /// Find all DocumentType.
        /// </summary>
        /// <returns> All DocumentType</returns>
        IList<DocumentType> FindAll();

        void Add(DocumentType documentType);
    }
}

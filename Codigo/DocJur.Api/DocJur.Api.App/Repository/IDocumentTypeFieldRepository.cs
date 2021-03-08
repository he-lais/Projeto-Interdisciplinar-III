using DocJur.Api.App.Models;
using System;
using System.Collections.Generic;

namespace DocJur.Api.App.Repository
{
    public interface IDocumentTypeFieldRepository
    {
        void Add(DocumentTypeField documentTypeField);

        IList<DocumentTypeField> FindByDocumentType(Guid id);
    }
}

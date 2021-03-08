using DocJur.Api.App.Models;
using Microsoft.EntityFrameworkCore;

namespace DocJur.Api.App.Database
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }
        public DbSet<Document> Documents { get; set; }
        public DbSet<DocumentType> DocumentTypes { get; set; }
        public DbSet<DocumentTypeField> DocumentTypeFields { get; set; }
        public DbSet<User> Users { get; set; }
    }
}

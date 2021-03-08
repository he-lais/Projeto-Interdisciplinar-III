using DocJur.Api.App.Models;
using DocJur.Api.App.Utilities;
using System;
using System.Linq;

namespace DocJur.Api.App.Database
{
    /// <summary>
    /// Routines to initialize the database.
    /// </summary>
    public static class DatabaseInit
    {
        private const string DABASE_CANT_CONECT = "Error: Can't connect to the database.";

        /// <summary>
        /// Initialization of the database.
        /// </summary>
        /// <param name="databaseContext"></param>
        public static void Execute(DatabaseContext databaseContext)
        {
            if (databaseContext is null)
            {
                throw new ArgumentNullException(nameof(databaseContext));
            }

            databaseContext.Database.EnsureCreated();

            if (!databaseContext.Database.CanConnect())
            {
                throw new DocJurException(DABASE_CANT_CONECT);
            }

            CreateDefaultUser(databaseContext);
        }

        /// <summary>
        /// Add a default user to the DB if there is no users.
        /// </summary>
        /// <param name="DatabaseContext"></param>
        private static void CreateDefaultUser(DatabaseContext DatabaseContext)
        {
            if (!DatabaseContext.Users.Any())
            {
                User defaultUser = new User()
                {
                    Email = "admin@admin.com",
                    Password = "123456",
                    Username = "admin"
                };

                DatabaseContext.Users.Add(defaultUser);
            }

            DatabaseContext.SaveChanges();
        }
    }
}

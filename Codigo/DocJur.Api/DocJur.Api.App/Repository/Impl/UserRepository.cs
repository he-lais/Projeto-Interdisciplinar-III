using DocJur.Api.App.Database;
using DocJur.Api.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DocJur.Api.App.Repository.Impl
{
    /// <summary>
    /// Repository to manage entities from users table.
    /// </summary>
    public class UserRepository : IUserRepository
    {
        private DatabaseContext DatabaseContext { get; set; }

        /// <summary>
        /// Find one User by the id
        /// </summary>
        /// <param name="id">User Id</param>
        /// <returns></returns>
        public User Find(Guid id)
        {
            return DatabaseContext.Users.Find(id);
        }

        /// <summary>
        /// Find one User by the username and password.
        /// </summary>
        /// <param name="username">User username</param>
        /// <param name="password">User password</param>
        /// <returns></returns>
        public User FindByUsernameAndPassword(string username, string password)
        {
            return DatabaseContext.Users.Where(u => u.Username == username && u.Password == password).FirstOrDefault();
        }

        public User FindByUsername(string username)
        {
            return DatabaseContext.Users.Where(u => u.Username == username).FirstOrDefault();
        }

        /// <summary>
        /// Find all Users.
        /// </summary>
        /// <returns></returns>
        public IList<User> FindAll()
        {
            return DatabaseContext.Users.ToList();
        }

        /// <summary>
        /// Add a new User into the repository.
        /// </summary>
        /// <param name="user"></param>
        public void Add(User user)
        {
            DatabaseContext.Users.Add(user);
            DatabaseContext.SaveChanges();
        }

        /// <summary>
        /// Update a User into the repository.
        /// </summary>
        /// <param name="user"></param>
        public void Update(User user)
        {
            DatabaseContext.Users.Update(user);
            DatabaseContext.SaveChanges();
        }

        /// <summary>
        /// Delete a User from the repository.
        /// </summary>
        /// <param name="user"></param>
        public void Delete(User user)
        {
            DatabaseContext.Users.Remove(user);
            DatabaseContext.SaveChanges();
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="databaseContext"></param>
        public UserRepository(DatabaseContext databaseContext)
        {
            DatabaseContext = databaseContext;
        }
    }
}

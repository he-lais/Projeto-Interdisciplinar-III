using DocJur.Api.App.Models;
using System;
using System.Collections.Generic;

namespace DocJur.Api.App.Repository
{
    /// <summary>
    /// Repository to manage entities from users table.
    /// </summary>
    public interface IUserRepository
    {
        /// <summary>
        /// Find one User by the id
        /// </summary>
        /// <param name="id">User Id</param>
        /// <returns></returns>
        User Find(Guid id);

        /// <summary>
        /// Find one User by the username and password.
        /// </summary>
        /// <param name="username">User username</param>
        /// <param name="password">User password</param>
        /// <returns></returns>
        User FindByUsernameAndPassword(string username, string password);
        User FindByUsername(string username);

        /// <summary>
        /// Find all Users.
        /// </summary>
        /// <returns></returns>
        IList<User> FindAll();

        /// <summary>
        /// Add a new User into the repository.
        /// </summary>
        /// <param name="User"></param>
        void Add(User user);

        /// <summary>
        /// Update a User into the repository.
        /// </summary>
        /// <param name="User"></param>
        void Update(User user);

        /// <summary>
        /// Delete a User from the repository.
        /// </summary>
        /// <param name="User"></param>
        void Delete(User user);
    }
}

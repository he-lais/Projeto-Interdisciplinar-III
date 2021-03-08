using System;

namespace DocJur.Api.App.Models.Responses.Users
{
    // User Login response structure.
    public class UserLoginResponse : BasicResponse
    {
        /// <summary>
        /// Authentication token.
        /// </summary>
        public string Token { get; set; }

        public string Name { get; set; }

        public Guid Id { get; set; }
    }
}

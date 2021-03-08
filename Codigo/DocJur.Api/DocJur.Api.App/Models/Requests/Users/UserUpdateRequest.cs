using System;

namespace DocJur.Api.App.Models.Requests.Users
{
    public class UserUpdateRequest : UserCreateRequest
    {
        /// <summary>
        /// Entity Id.
        /// </summary>
        public Guid Id { get; set; }
    }
}

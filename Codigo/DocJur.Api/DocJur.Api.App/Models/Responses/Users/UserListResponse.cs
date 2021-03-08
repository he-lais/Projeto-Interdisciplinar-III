using System.Collections.Generic;

namespace DocJur.Api.App.Models.Responses.Users
{
    public class UserListResponse : BasicResponse
    {
        public IList<User> Users { get; set; }

        public UserListResponse() : base() => Users = new List<User>();
    }
}

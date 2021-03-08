namespace DocJur.Api.App.Models.Responses.Users
{
    public class UserResponse : BasicResponse
    {
        public User User { get; set; }

        public UserResponse() : base() { }
    }
}

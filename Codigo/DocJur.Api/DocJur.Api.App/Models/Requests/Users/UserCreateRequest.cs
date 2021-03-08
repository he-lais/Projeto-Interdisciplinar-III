namespace DocJur.Api.App.Models.Requests.Users
{
    public class UserCreateRequest
    {
        /// <summary>
        /// User name used to identify the user.
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Email of the user.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Password used for authentication.
        /// </summary>
        public string Password { get; set; }
    }
}

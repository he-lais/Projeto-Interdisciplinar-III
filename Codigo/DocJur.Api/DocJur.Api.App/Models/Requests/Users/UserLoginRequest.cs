namespace DocJur.Api.App.Models.Requests.Users
{
    /// <summary>
    /// Structure of User login request.
    /// </summary>
    public class UserLoginRequest
    {
        /// <summary>
        /// Username
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Password.
        /// </summary>
        public string Password { get; set; }
    }
}

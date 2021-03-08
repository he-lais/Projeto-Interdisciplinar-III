using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace DocJur.Api.App.Models
{
    /// <summary>
    /// Representation of User entity.
    /// </summary>
    public class User : AppModel
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

        /// <summary>
        /// List of documents that belongs to the user.
        /// </summary>
        [JsonIgnore]
        public IList<Document> Documents { get; set; }


        /// <summary>
        /// Constructor.
        /// </summary>
        public User() : base()
        {
            Documents = new List<Document>();
        }

        public void ClearPassword()
        {
            Password = "*******";
        }
    }
}

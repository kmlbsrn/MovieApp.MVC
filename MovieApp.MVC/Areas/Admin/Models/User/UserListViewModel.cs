using System.Text.Json.Serialization;

namespace MovieApp.MVC.Areas.Admin.Models.User
{
    public class UserListViewModel
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("userName")]
        public string UserName { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("userType")]
        public UserTypeEnum UserType { get; set; }

        [JsonPropertyName("createdAt")]
        public DateTime CreatedAt { get; set; }
    }
}

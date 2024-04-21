using System.Text.Json.Serialization;

namespace MovieApp.MVC.Models.User
{
    public class UserDetailListModel:IModel
    {
        [JsonPropertyName("firstName")]
        public string? FirstName { get; set; }

        [JsonPropertyName("lastName")]
        public string? LastName { get; set; }

        [JsonPropertyName("profilePictureUrl")]
        public string? ProfilePictureUrl { get; set; }

        [JsonPropertyName("biography")]
        public string? Biography { get; set; }

        [JsonPropertyName("gender")]
        public bool? Gender { get; set; }

        [JsonPropertyName("birthDate")]
        public DateTime? BirthDate { get; set; }

        [JsonPropertyName("facebook")]
        public string? Facebook { get; set; }

        [JsonPropertyName("twitter")]
        public string? Twitter { get; set; }

        [JsonPropertyName("instagram")]
        public string? Instagram { get; set; }

        [JsonPropertyName("userId")]
        public int UserId { get; set; }
    }
}

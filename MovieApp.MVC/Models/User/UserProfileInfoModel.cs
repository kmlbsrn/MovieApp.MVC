using MovieApp.MVC.Models.Movie;
using MovieApp.MVC.Models.Review;
using System.Text.Json.Serialization;

namespace MovieApp.MVC.Models.User
{
    public class UserProfileInfoModel:IModel
    {
        [JsonPropertyName("id")]
        public int UserId { get; set; }

        [JsonPropertyName("userName")]
        public string UserName { get; set; }

        [JsonPropertyName("userEmail")]
        public string Email { get; set; }

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

        [JsonPropertyName("userDetailId")]
        public int UserDetailId { get; set; }

        [JsonPropertyName("favoriteFilm")]
        public List<MovieShortModel> UserFavorites { get; set; }

        [JsonPropertyName("reviews")]
        public List<ProfileListReviewModel> UsersReviews { get; set; }
    }
}

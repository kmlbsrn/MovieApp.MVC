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

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("favoriteFilm")]
        public List<MovieShortModel> UserFavorites { get; set; }

        [JsonPropertyName("reviews")]
        public List<ProfileListReviewModel> UsersReviews { get; set; }
    }
}

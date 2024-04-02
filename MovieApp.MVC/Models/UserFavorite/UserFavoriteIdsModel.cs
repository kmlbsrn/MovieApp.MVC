using System.Text.Json.Serialization;

namespace MovieApp.MVC.Models.UserFavorite
{
    public class UserFavoriteIdsModel:IModel
    {
        [JsonPropertyName("userId")]
        public int UserId { get; set; }

        [JsonPropertyName("movieId")]
        public List<int> MovieId { get; set; }
    }
}

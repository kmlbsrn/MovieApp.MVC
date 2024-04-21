using System.Text.Json.Serialization;

namespace MovieApp.MVC.Models.Movie
{
    public class FavoriteMovieModel:MovieShortModel
    {
        [JsonPropertyName("favoriteCount")]
        public int FavoriteCount { get; set; }
    }
}

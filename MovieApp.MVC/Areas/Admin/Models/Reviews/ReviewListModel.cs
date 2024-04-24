using MovieApp.MVC.Models;
using MovieApp.MVC.Models.Review;
using System.Text.Json.Serialization;

namespace MovieApp.MVC.Areas.Admin.Models.Reviews
{
    public class ReviewListModel:ProfileListReviewModel,IModel
    {

        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("reviewText")]
        public string ReviewText { get; set; }

        [JsonPropertyName("rating")]
        public int Rating { get; set; }

        [JsonPropertyName("movieId")]
        public int MovieId { get; set; }

        [JsonPropertyName("movieName")]
        public string MovieName { get; set; }

        [JsonPropertyName("moviePoster")]
        public string MoviePoster { get; set; }

        [JsonPropertyName("createdDate")]
        public string CreatedDate { get; set; }
    }
}

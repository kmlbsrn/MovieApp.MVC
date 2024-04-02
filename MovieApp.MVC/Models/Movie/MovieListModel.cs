
using System.Text.Json.Serialization;

namespace MovieApp.MVC.Models.Movie
{
    public class MovieListModel<T>
        where T: class,IModel
    {
        [JsonPropertyName("page")]
        public int Page { get; set; }

        [JsonPropertyName("results")]
        public List<T> Results { get; set; }

        [JsonPropertyName("total_pages")]
        public int TotalPages { get; set; }

        [JsonPropertyName("total_results")]
        public int TotalResults { get; set; }
    }
}

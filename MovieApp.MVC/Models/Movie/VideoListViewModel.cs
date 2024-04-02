using System.Text.Json.Serialization;

namespace MovieApp.MVC.Models.Movie
{
    public class VideoListViewModel:IModel
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("results")]
        public List<VideoViewModel> Results { get; set; }

    }
}

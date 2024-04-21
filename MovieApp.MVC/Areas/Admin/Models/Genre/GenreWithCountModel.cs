using System.Text.Json.Serialization;

namespace MovieApp.MVC.Areas.Admin.Models.Genre
{
    public class GenreWithCountModel
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("count")]
        public int MovieCount { get; set; }
    }
}

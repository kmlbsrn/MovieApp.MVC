using System.Text.Json.Serialization;

namespace MovieApp.MVC.Models.Movie
{
    public class MovieTrailerModel:IModel
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("key")]
        public string Key { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("site")]
        public string Site { get; set; }

        [JsonPropertyName("size")]
        public int? Size { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("backdropPath")]
        public string BackdropPath { get; set; }

    }
}

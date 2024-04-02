using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace MovieApp.MVC.Models.Movie
{
    public class GenreModel:IModel
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}
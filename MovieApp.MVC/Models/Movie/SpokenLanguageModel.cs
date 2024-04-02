using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace MovieApp.MVC.Models.Movie
{
    public class SpokenLanguageModel:IModel
    {
        [JsonPropertyName("english_name")]
        public string EnglishName { get; set; }

        [JsonPropertyName("iso_639_1")]
        public string Iso_639_1 { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}
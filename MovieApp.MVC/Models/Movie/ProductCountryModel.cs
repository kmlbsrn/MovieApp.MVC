using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace MovieApp.MVC.Models.Movie
{
    public class ProductCountryModel:IModel
    {
        [JsonPropertyName("iso_3166_1")]
        public string Iso_3166_1 { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}

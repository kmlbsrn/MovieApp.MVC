using System.Text.Json.Serialization;

namespace MovieApp.MVC.Models.Credits
{
    public class FilmographyModel:IModel
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("cast")]
        public List<CastFilmographyModel> Cast { get; set; }

        [JsonPropertyName("crew")]
        public List<CrewFilmographyModel> Crew { get; set; }
    }
}

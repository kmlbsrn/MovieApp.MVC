using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace MovieApp.MVC.Models.Credits
{
    public class CreditsListViewModel:IModel
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("cast")]
        public List<CastListViewModel> Cast { get; set; }

        [JsonPropertyName("crew")]
        public List<CrewListViewModel> Crew { get; set; }
    }
}

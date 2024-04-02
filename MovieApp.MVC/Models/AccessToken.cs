
using System.Text.Json.Serialization;

namespace MovieApp.MVC.Models
{
    public class AccessToken
    {
        [JsonPropertyName("accessToken")]
        public string Token { get; set; }

        public DateTime Expiration { get; set; }
    }
}

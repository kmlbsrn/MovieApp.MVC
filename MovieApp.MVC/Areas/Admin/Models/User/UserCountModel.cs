using System.Text.Json.Serialization;

namespace MovieApp.MVC.Areas.Admin.Models.User
{
    public class UserCountModel
    {
        [JsonPropertyName("month")]
        public int Month { get; set; }

        [JsonPropertyName("userCount")]
        public int UserCount { get; set; }
    }
}

using System.Text.Json.Serialization;

namespace MovieApp.MVC.Areas.Admin.Models.Genre
{
    public class GenreListModel
    {

        [JsonPropertyName("genres")]
        public List<GenreWithCountModel> Genres { get; set; }

    }
}

using System.Text.Json.Serialization;

namespace MovieApp.MVC.Models.Review
{
    public class ProfileListReviewModel
    {

        //    "id": 21,
        //"reviewText": "çok güzel bir film ",
        //"rating": 5,
        //"movieId": 823464,
        //"movieName": "Godzilla ve Kong: Yeni İmparatorluk",
        //"moviePoster": "/drw6bZFRP1Yv5LNFW0KLoAgWo5.jpg",
        //"createdDate": "2024-03-31T18:17:01.0921314"[]

        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("reviewText")]
        public string ReviewText { get; set; }

        [JsonPropertyName("rating")]
        public int Rating { get; set; }

        [JsonPropertyName("movieId")]
        public int MovieId { get; set; }

        [JsonPropertyName("movieName")]
        public string MovieName { get; set; }

        [JsonPropertyName("moviePoster")]
        public string MoviePoster { get; set; }

        [JsonPropertyName("createdDate")]
        public string CreatedDate { get; set; }
    }
}

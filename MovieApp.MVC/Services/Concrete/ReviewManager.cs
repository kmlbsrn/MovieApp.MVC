using MovieApp.MVC.Models.Result;
using MovieApp.MVC.Models.Review;
using MovieApp.MVC.Services.Abstract;
using RestSharp;

namespace MovieApp.MVC.Services.Concrete
{
    public class ReviewManager : IReviewService
    {
        private readonly ApiService _apiService;

        public ReviewManager(ApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<MovieApp.MVC.Models.Result.IResult> AddReview(AddReviewModel addReviewModel)
        {
        
            var response = await _apiService.ExecuteMovieApiRequestAsync("Review/add", Method.Post, addReviewModel);
            return await _apiService.ProcessApiResponseAsync<MovieApp.MVC.Models.Result.Result>(response);
        
        }

        public async Task<List<ReviewListModel>> GetReviewsByMovieId(int movieId)
        {
            var response = await _apiService.ExecuteMovieApiRequestAsync($"Review/getreviewsbymovieid?movieId={movieId}", Method.Get);
            //respose'un içindeki json'daki data kısmını ReviewListModel'e çevirip döndürüyoruz.
            
            return await _apiService.ProcessApiResponseAsync<List<ReviewListModel>>(response);


           
   

            

        }
    }
}

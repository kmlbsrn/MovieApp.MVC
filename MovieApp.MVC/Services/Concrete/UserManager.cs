using MovieApp.MVC.Models.Movie;
using MovieApp.MVC.Models.Result;
using MovieApp.MVC.Models.Review;
using MovieApp.MVC.Models.User;
using MovieApp.MVC.Models.UserFavorite;
using MovieApp.MVC.Services.Abstract;
using RestSharp;

namespace MovieApp.MVC.Services.Concrete
{
    public class UserManager : IUserService
    {
        private readonly ApiService _apiService;

        public UserManager(ApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<Result> AddFavorite(int movieId)
        {
            // https://localhost:7135/api/UserFavorites

            var response = await _apiService.ExecuteMovieApiRequestAsync("Users/AddUserFavorite", Method.Post, new { movieId });
            return await _apiService.ProcessApiResponseAsync<Result>(response);


        }

        public async Task<Models.Result.IResult> ChangeFavorite(int movieId)
        {
            var response =  await _apiService.ExecuteMovieApiRequestAsync("Users/changeFavoriteStat", Method.Patch,new {movieId});
            return await _apiService.ProcessApiResponseAsync<Models.Result.Result>(response);
        }

        public async Task<UserProfileInfoModel> GetProfileUserInfoById(int id)
        {
           var response = await _apiService.ExecuteMovieApiRequestAsync($"Users/getuserinfobyid?userId={id}", Method.Get);
            return await _apiService.ProcessApiResponseAsync<UserProfileInfoModel>(response);
        }

        public async Task<UserFavoriteIdsModel> GetUserFavoriteIds()
        {
            var response = await _apiService.ExecuteMovieApiRequestAsync("Users/getAllUserFavoriteId", Method.Get);
            return  await _apiService.ProcessApiResponseAsync<UserFavoriteIdsModel>(response);
        }

        public async Task<List<MovieShortModel>> GetUserFavoritesMovieByUserId(int userId)
        {
            var response = await _apiService.ExecuteMovieApiRequestAsync($"Users/getAllFavoriteByUserId?userId={userId}", Method.Get);
            return await _apiService.ProcessApiResponseAsync<List<MovieShortModel>>(response);
        }

        public async Task<List<MovieShortModel>> GetUserFavoritesWithMovies()
        {
            var response = await _apiService.ExecuteMovieApiRequestAsync("Users/getAllMyFavorite", Method.Get);
            return await _apiService.ProcessApiResponseAsync<List<MovieShortModel>>(response);
        }

        public async Task<List<ProfileListReviewModel>> GetUserReviewsById(int userId)
        {
            var response = await _apiService.ExecuteMovieApiRequestAsync($"Review/getreviewsbyuserid?userId={userId}", Method.Get);
            return await _apiService.ProcessApiResponseAsync<List<ProfileListReviewModel>>(response);
        }

        public async Task<List<ProfileListReviewModel>> GetUsersReviews()
        {
            var response = await _apiService.ExecuteMovieApiRequestAsync("Review/getuserreviews", Method.Get);
            return await _apiService.ProcessApiResponseAsync<List<ProfileListReviewModel>>(response);
        }
    }
}

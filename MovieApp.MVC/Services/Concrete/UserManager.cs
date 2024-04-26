using MovieApp.MVC.Areas.Admin.Models.User;
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

        public Task<Result> AddUserDetail(AddUserDetailReq data)
        {
            var response = _apiService.ExecuteMovieApiRequestAsync("Users/addUserDetail", Method.Post, data);
            return _apiService.ProcessApiResponseAsync<Result>(response.Result);
        }

        public async Task<Models.Result.IResult> ChangeFavorite(int movieId)
        {
            var response =  await _apiService.ExecuteMovieApiRequestAsync("Users/changeFavoriteStat", Method.Patch,new {movieId});
            return await _apiService.ProcessApiResponseAsync<Models.Result.Result>(response);
        }

        public async Task<Result> Delete(int id)
        {
            var response = await _apiService.ExecuteMovieApiRequestAsync($"/Users/deleteUser?userId={id}", Method.Delete);
            return await _apiService.ProcessApiResponseAsync<Result>(response);
        }

        public async Task<List<UserListViewModel>> GetAllUsers()
        {
            var response = await _apiService.ExecuteMovieApiRequestAsync("Users/GetAllUsers", Method.Get);
            return await _apiService.ProcessApiResponseAsync<List<UserListViewModel>>(response);
        }

        public async Task<List<FavoriteMovieModel>> GetMostFavoriteMovie()
        {
            var response =  await _apiService.ExecuteMovieApiRequestAsync("Users/GetMostFavoriteMovie", Method.Get);
            return await _apiService.ProcessApiResponseAsync<List<FavoriteMovieModel>>(response);
        }

        public async Task<UserProfileInfoModel> GetProfileUserInfoById(int id)
        {
           var response = await _apiService.ExecuteMovieApiRequestAsync($"Users/getuserinfobyid?userId={id}", Method.Get);
            return await _apiService.ProcessApiResponseAsync<UserProfileInfoModel>(response);
        }

        public Task<UserDetailListModel> GetUserDetail()
        {
            
            var response = _apiService.ExecuteMovieApiRequestAsync("Users/getUserDetail", Method.Get);
            return _apiService.ProcessApiResponseAsync<UserDetailListModel>(response.Result);
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

        public async Task<UserProfileInfoModel> GetUserInfo(int userId)
        {
            var response = await _apiService.ExecuteMovieApiRequestAsync($"Users/getuserinfobyid?userId={userId}", Method.Get);
            return await _apiService.ProcessApiResponseAsync<UserProfileInfoModel>(response);
        }

        public async Task<UserProfileInfoModel> GetUserInfo()
        {
            var response = await _apiService.ExecuteMovieApiRequestAsync("/Users/getUserDetail", Method.Get);
            return await _apiService.ProcessApiResponseAsync<UserProfileInfoModel>(response);
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

        public async Task<List<UserCountModel>> GetYearlyUserCount()
        {
            var response = await _apiService.ExecuteMovieApiRequestAsync("Users/GetYearlyUserCount", Method.Get);
            return await _apiService.ProcessApiResponseAsync<List<UserCountModel>>(response);
        }
    }
}

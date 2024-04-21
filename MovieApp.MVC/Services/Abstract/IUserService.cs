using MovieApp.MVC.Areas.Admin.Models.User;
using MovieApp.MVC.Models.Movie;
using MovieApp.MVC.Models.Result;
using MovieApp.MVC.Models.Review;
using MovieApp.MVC.Models.User;
using MovieApp.MVC.Models.UserFavorite;

namespace MovieApp.MVC.Services.Abstract
{
    public interface IUserService
    {
      

        Task<Result> AddFavorite(int movieId);

        //Get User Favorites
        Task<List<MovieShortModel>> GetUserFavoritesWithMovies();

        Task<List<MovieShortModel>> GetUserFavoritesMovieByUserId(int userId);

        Task<UserFavoriteIdsModel> GetUserFavoriteIds();

        Task<List<ProfileListReviewModel>> GetUsersReviews();

        Task<List<ProfileListReviewModel>> GetUserReviewsById(int userId);

        Task<Models.Result.IResult> ChangeFavorite(int movieId);

        Task<UserProfileInfoModel> GetProfileUserInfoById(int id);

        Task<List<UserListViewModel>> GetAllUsers();

        Task<List<FavoriteMovieModel>> GetMostFavoriteMovie();

        Task<List<UserCountModel>> GetYearlyUserCount();

        Task<Result> Delete(int id);

        Task<Result> AddUserDetail(AddUserDetailReq data);

        Task<UserDetailListModel> GetUserDetail();

    }
}

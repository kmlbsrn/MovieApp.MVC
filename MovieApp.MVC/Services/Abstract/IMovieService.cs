using MovieApp.MVC.Models.Movie;
using System.Linq.Expressions;

namespace MovieApp.MVC.Services.Abstract
{
    public interface IMovieService
    {


        Task<MovieListModel<MovieModel>> GetUpcomingMovies();
        Task<MovieDetailModel> GetMovieDetail(int id);

        Task<VideoListViewModel> GetMovieVideos(int id,string type);


        Task<VideoListViewModel> GetMovieVideos(int id);

        Task<MovieListModel<SearchMovieModel>> GetMoviesByQuery(string query,int pageNumber=1);

        Task<MovieListModel<MovieModel>> GetTopRatedMovies();
    }
}

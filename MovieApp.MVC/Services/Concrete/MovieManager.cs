using MovieApp.MVC.Areas.Admin.Models.Genre;
using MovieApp.MVC.Models.Movie;
using MovieApp.MVC.Services.Abstract;
using RestSharp;

namespace MovieApp.MVC.Services.Concrete
{
    public class MovieManager : IMovieService
    {
        private readonly ApiService _apiService;

        public MovieManager(ApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<MovieDetailModel> GetMovieDetail(int id)
        {
           
            var response = await _apiService.ExecuteMovieApiRequestAsync($"Movie/getbyid?id={id}", Method.Get);
            return await _apiService.ProcessApiResponseAsync<MovieDetailModel>(response);
        }

        public async Task<MovieListModel<SearchMovieModel>> GetMoviesByQuery(string query,int pageNumber=1)
        {
            var response = await _apiService.ExecuteMovieApiRequestAsync($"Movie/getbysearchquery?query={query}&pageNumber={pageNumber}", Method.Get);
            return await _apiService.ProcessApiResponseAsync<MovieListModel<SearchMovieModel>>(response);
        }

        public async Task<VideoListViewModel> GetMovieVideos(int id, string type)
        {
            
            var response = await _apiService.ExecuteMovieApiRequestAsync($"Movie/getvideos?id={id}&type={type}", Method.Get);
            return await _apiService.ProcessApiResponseAsync<VideoListViewModel>(response);
        }

        public async Task<VideoListViewModel> GetMovieVideos(int id)
        {
            var response = await _apiService.ExecuteMovieApiRequestAsync($"Movie/getvideos?movieId={id}", Method.Get);
            return await _apiService.ProcessApiResponseAsync<VideoListViewModel>(response);
        }

        public async Task<GenreListModel> GetPopularGenre()
        {
            var response = await _apiService.ExecuteMovieApiRequestAsync("/Movie/getpopulargenres", Method.Get);
            return await _apiService.ProcessApiResponseAsync<GenreListModel>(response);
        }

        public async Task<MovieListModel<MovieModel>> GetTopRatedMovies(int pageNumber=1)
        {
            var response = await _apiService.ExecuteMovieApiRequestAsync($"Movie/gettopratedmovies?pageNumber={pageNumber}", Method.Get);
            return await _apiService.ProcessApiResponseAsync<MovieListModel<MovieModel>>(response);
        }

        public async Task<MovieListModel<MovieModel>> GetTopRatedMoviesList()
        {
            var response = await _apiService.ExecuteMovieApiRequestAsync("Movie/gettopratedmovies", Method.Get);
            return await _apiService.ProcessApiResponseAsync<MovieListModel<MovieModel>>(response);
        }

        public async Task<MovieListModel<MovieModel>> GetUpcomingMovies()
        {
            
            var response = await _apiService.ExecuteMovieApiRequestAsync("Movie/getupcomingmovies", Method.Get);
            return await _apiService.ProcessApiResponseAsync<MovieListModel<MovieModel>>(response);

        }

        public async Task<List<MovieTrailerModel>> GetUpComingTrailer()
        {
            var response =await _apiService.ExecuteMovieApiRequestAsync("/Movie/GetUpComingMovieTrailer", Method.Get);
            return await _apiService.ProcessApiResponseAsync<List<MovieTrailerModel>>(response);
        }
    }
}

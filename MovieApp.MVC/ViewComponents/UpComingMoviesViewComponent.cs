using Microsoft.AspNetCore.Mvc;
using MovieApp.MVC.Extensions;
using MovieApp.MVC.Models.Movie;
using MovieApp.MVC.Services.Abstract;

namespace MovieApp.MVC.ViewComponents
{
    public class UpComingMoviesViewComponent:ViewComponent
    {
        private readonly IMovieService _movieService;
        private readonly IUserService _userService;



        public UpComingMoviesViewComponent(IMovieService movieService, IUserService userService)
        {
            _movieService = movieService;
            _userService = userService;
        }


        public IViewComponentResult Invoke()
        {

            var upcomingMovies = _movieService.GetUpcomingMovies().Result;

            if (User.Identity.IsAuthenticated)
            {

                var userFavorites = _userService.GetUserFavoriteIds().Result.MovieId;


                foreach (var movie in upcomingMovies.Results)
                {
                    if (userFavorites.Contains(movie.Id))
                    {
                        movie.IsFavorite = true;
                    }
                }
               

            }
         

            return View(upcomingMovies);
        }

        // script


       
    }
}

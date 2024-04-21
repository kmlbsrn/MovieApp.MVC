using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieApp.MVC.Areas.Admin.Models.Genre;
using MovieApp.MVC.Areas.Admin.Models.User;
using MovieApp.MVC.Models.Movie;
using MovieApp.MVC.Services.Abstract;
using System.Security.Claims;

namespace MovieApp.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Policy = "Admin")]
    public class HomeController : Controller
    {
        private readonly IUserService _userService;
        private readonly IMovieService _movieService;
        public HomeController(IUserService userService,IMovieService movieService)
        {
            _userService = userService;
            _movieService = movieService;
        }

        public IActionResult Index()
        {
            var mostFavoriteMovies = _userService.GetMostFavoriteMovie().Result;

            var userCount = _userService.GetYearlyUserCount().Result;

            var popularGenres = _movieService.GetPopularGenre().Result;

           

            var viewModel= new Tuple<List<FavoriteMovieModel>, List<UserCountModel>,GenreListModel>(mostFavoriteMovies, userCount,popularGenres);



            return View(viewModel);
        }
         
        
    }
}

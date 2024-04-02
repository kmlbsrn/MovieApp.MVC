using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieApp.MVC.Services.Abstract;

namespace MovieApp.MVC.Controllers
{
    public class ProfileController : Controller
    {

        private readonly IUserService _userService;

        public ProfileController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("myProfile")]
        [Authorize(Roles ="User")]
        public IActionResult Index()
        {

            var userFavorites = _userService.GetUserFavoritesWithMovies().Result;

            var usersReviews = _userService.GetUsersReviews().Result;

            var viewModel= Tuple.Create(userFavorites, usersReviews);
            

            return View(viewModel);
        }

        [HttpGet("userProfile")]

        public IActionResult OtherProfile(int userId)
        {
           var viewModel = _userService.GetProfileUserInfoById(userId).Result;

            
            return View("OtherUserProfile",viewModel);
            
        }
    }
}

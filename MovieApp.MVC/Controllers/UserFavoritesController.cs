using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieApp.MVC.Services.Abstract;
using System.Security.Claims;

namespace MovieApp.MVC.Controllers
{
    public class UserFavoritesController : Controller
    {
        
        private readonly IUserService _userService;

        
        public UserFavoritesController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public IActionResult Add(int id)
        {
            var result = _userService.AddFavorite(id).Result;


            TempData["SuccessMessage"] = result.Message;

            return RedirectToAction("Index","Home");
        }

        [HttpPost]
        public IActionResult ChangeFavorite(int movieId)
        {

            var result = _userService.ChangeFavorite(movieId).Result;

            if (result.Success)
            {
                TempData["SuccessMessage"] = result.Message;
            }


            return RedirectToAction("Index", "Home");
        }
    }
}

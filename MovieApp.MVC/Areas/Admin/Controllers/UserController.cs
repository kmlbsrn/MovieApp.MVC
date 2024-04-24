using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieApp.MVC.Services.Abstract;

namespace MovieApp.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles ="Admin")]
    public class UserController : Controller
    {

        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult List()
        {
            var viewModel = _userService.GetAllUsers().Result;


            return View(viewModel);
        }

        public IActionResult Delete(int id)
        {

            var result = _userService.Delete(id).Result;

            if (result.Success)
            {
                return RedirectToAction("List");
            }
            else
            {
                TempData["Error"] = result.Message;
                return RedirectToAction("List");
            }
        }

        public IActionResult GetUserReviews(int userId)
        {
         var viewModel = _userService.GetUserReviewsById(userId);

            if (viewModel.IsCompletedSuccessfully)
            {
                return View("Reviews",viewModel.Result);
            }
            else
            {
                TempData["Error"] = "Kullanıcı yorumları getirilirken bir hata oluştu.";
                return RedirectToAction("List");
            }
        }

        public IActionResult UserDetail(int userId)
        {
            var viewModel = _userService.GetProfileUserInfoById(userId);

            //if (viewModel.IsCompleted)
            //{
                return View("UserDetail",viewModel.Result);
            //}
            //else
            //{
            //    TempData["Error"] = "Kullanıcı detayları getirilirken bir hata oluştu.";
            //    return RedirectToAction("List");
            //}

        }
        
    }
}

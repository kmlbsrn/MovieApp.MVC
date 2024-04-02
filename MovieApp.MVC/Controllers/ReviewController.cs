using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using MovieApp.MVC.Models.Movie;
using MovieApp.MVC.Models.Review;
using MovieApp.MVC.Services.Abstract;

namespace MovieApp.MVC.Controllers
{
    public class ReviewController : Controller
    {

        private readonly IReviewService _reviewService;

        public ReviewController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        [HttpPost]
        public IActionResult Add(AddReviewModel formData)
        {

            try
            {
             var result = _reviewService.AddReview(formData).Result;


                if (result.Success)
                {
                    TempData["SuccessMessage"] = "Review added successfully";

                    return RedirectToAction("Detail", "Movie", new { id = formData.MovieId });
                }

                return RedirectToAction("Index", "Home");

            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
                return RedirectToAction("Index", "Home");
            }
 
        }


    }
}

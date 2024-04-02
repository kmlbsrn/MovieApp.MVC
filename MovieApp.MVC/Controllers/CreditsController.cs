using Microsoft.AspNetCore.Mvc;
using MovieApp.MVC.Models.Credits;
using MovieApp.MVC.Services.Abstract;

namespace MovieApp.MVC.Controllers
{
    public class CreditsController : Controller
    {

        private readonly ICreditsService _creditsService;

        public CreditsController(ICreditsService creditsService)
        {
            _creditsService = creditsService;
        }


        [HttpGet]
        public IActionResult Detail(int id)
        {
            var actorDetail = _creditsService.GetActorDetail(id).Result;

            var filmography = _creditsService.GetFilmography(id).Result;

            var viewModel= new Tuple<ActorDetailModel, FilmographyModel>(actorDetail, filmography);

            return View(viewModel);
        }
    }
}

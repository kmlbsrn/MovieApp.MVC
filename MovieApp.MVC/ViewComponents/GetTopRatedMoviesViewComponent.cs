using Microsoft.AspNetCore.Mvc;
using MovieApp.MVC.Services.Abstract;

namespace MovieApp.MVC.ViewComponents
{
    public class GetTopRatedMoviesViewComponent : ViewComponent
    {

        private readonly IMovieService _movieService;

        public GetTopRatedMoviesViewComponent(IMovieService movieService)
        {
            _movieService = movieService;
        }

        public IViewComponentResult Invoke()
        {

            var model = _movieService.GetTopRatedMovies().Result;


            if (model is not null)
            {

                // max 5 movies
                if (model.Results.Count > 5)
                {
                    model.Results = model.Results.GetRange(0, 5);
                }

                return View(model);
            }

            return View(model);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using MovieApp.MVC.Services.Abstract;

namespace MovieApp.MVC.ViewComponents
{
    public class GetUpComingMovieVideoViewComponent : ViewComponent
    {
        private readonly IMovieService _movieService;
        private readonly ILogger<GetUpComingMovieVideoViewComponent> _logger;

        public GetUpComingMovieVideoViewComponent(IMovieService movieService, ILogger<GetUpComingMovieVideoViewComponent> logger)
        {
            _movieService = movieService;
            _logger = logger;
        }

        public IViewComponentResult Invoke()
        {
            try
            {
                var viewModel = _movieService.GetUpComingTrailer();

                if (viewModel.Result == null)
                {
                    return View();
                }

                return View(viewModel.Result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while getting the upcoming movie trailer.");
                return View("Error");
            }
        }
    }
}

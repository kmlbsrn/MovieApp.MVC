using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieApp.MVC.Common.Enums;
using MovieApp.MVC.Models.Credits;
using MovieApp.MVC.Models.Movie;
using MovieApp.MVC.Models.Review;
using MovieApp.MVC.Services.Abstract;

namespace MovieApp.MVC.Controllers
{
    [Authorize]
    public class MovieController : Controller
    {
        private readonly IMovieService _movieService;
        private readonly IReviewService _reviewService;
        private readonly ICreditsService _creditsService;
        private readonly IConfiguration _configuration;



        public MovieController(IMovieService movieService, IReviewService reviewService, ICreditsService creditsService, IConfiguration configuration)
        {
            _movieService = movieService;
            _reviewService = reviewService;
            _creditsService = creditsService;
            _configuration = configuration;
        }

        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.apiBaseUrl = _configuration["AppSettings:apiUrl"];

            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Detail(int id)
        {
            var movieDetail = _movieService.GetMovieDetail(id).Result;

            var reviewListModel = _reviewService.GetReviewsByMovieId(id).Result;

            var credits = _creditsService.GetCreditsByMovieId(id).Result;

            var videoListModel = _movieService.GetMovieVideos(id).Result;


            // create tupples for the view model
            var viewModel = new Tuple<MovieDetailModel, List<ReviewListModel>, CreditsListViewModel, VideoListViewModel>(movieDetail, reviewListModel, credits, videoListModel);

            return View(viewModel);
        }



        [HttpPost]
        [AllowAnonymous]
        public IActionResult Search(string query)
        {
            var movieListModel = _movieService.GetMoviesByQuery(query).Result;

            ViewBag.Query = query;

            return View(movieListModel);
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Pagination(string query, int pageNumber)
        {
            // İstenilen sayfa numarasına göre belirli bir sorgu ile sayfalama işlemi yapılabilir.
            var movieListModel = _movieService.GetMoviesByQuery(query, pageNumber).Result;

            // Gerekirse sayfalamaya ait diğer veriler de hesaplanabilir veya ayarlanabilir.

            // Sayfa numarası ve sorgu bilgisi view'e gönderilir.
            ViewBag.Query = query;
            ViewBag.PageNumber = pageNumber;

            return View("Search",movieListModel);
        }




    }
}

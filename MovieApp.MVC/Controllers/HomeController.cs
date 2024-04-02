using Microsoft.AspNetCore.Mvc;
using MovieApp.MVC.Extensions;

namespace MovieApp.MVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
           
      

            return View();
        }
    }
}

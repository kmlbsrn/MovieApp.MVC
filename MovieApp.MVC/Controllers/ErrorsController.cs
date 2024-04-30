using Microsoft.AspNetCore.Mvc;

namespace MovieApp.MVC.Controllers
{
    public class ErrorsController : Controller
    {
        public IActionResult Error404()
        {
            return View();
        }
    }
}

﻿using Microsoft.AspNetCore.Mvc;

namespace MovieApp.MVC.ViewComponents
{
    public class NavbarViewComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}

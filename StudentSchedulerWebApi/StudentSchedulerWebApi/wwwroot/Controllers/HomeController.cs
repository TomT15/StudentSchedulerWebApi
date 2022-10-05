﻿using Microsoft.AspNetCore.Mvc;

namespace StudentSchedulerWebApi
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View("~/Views/Home/Index.cshtml");
        }
    }
}

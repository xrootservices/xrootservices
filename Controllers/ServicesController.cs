﻿using Microsoft.AspNetCore.Mvc;

namespace xRootServices.Controllers
{
    public class ServicesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

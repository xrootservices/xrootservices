﻿using Microsoft.AspNetCore.Mvc;

namespace xRootServices.Controllers
{
    [Route("Web-Scraping-Services")]
    public class WebScrapingServices : Controller
    {
        [HttpGet("")]
        public IActionResult Index()
        {
            return View();
        }
    }
}

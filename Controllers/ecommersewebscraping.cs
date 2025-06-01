using Microsoft.AspNetCore.Mvc;

namespace xRootServices.Controllers
{

    [Route("e-commerse-web-scraping")]
    public class ecommersewebscraping : Controller
    {
        [HttpGet("")]
        public IActionResult Index()
        {
            return View();
        }
    }
}

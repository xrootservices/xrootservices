using Microsoft.AspNetCore.Mvc;

namespace xRootServices.Controllers
{
    public class Blogs : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

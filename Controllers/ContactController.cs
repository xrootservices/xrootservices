using Microsoft.AspNetCore.Mvc;

namespace xRootServices.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

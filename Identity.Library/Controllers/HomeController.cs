using Microsoft.AspNetCore.Mvc;

namespace Identity.Library.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

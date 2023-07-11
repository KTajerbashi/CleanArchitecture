using Microsoft.AspNetCore.Mvc;

namespace Library_Clean_Architecture.Controllers
{
    public class ExceptionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

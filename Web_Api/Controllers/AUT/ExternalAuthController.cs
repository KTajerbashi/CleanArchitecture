using Microsoft.AspNetCore.Mvc;

namespace Web_Api.Controllers.AUT
{
    public class ExternalAuthController : Controller
    {
        public IActionResult Index()
        {
            HttpClient client = new HttpClient();
            var result = client.GetStringAsync("");
            return View();
        }
    }
}

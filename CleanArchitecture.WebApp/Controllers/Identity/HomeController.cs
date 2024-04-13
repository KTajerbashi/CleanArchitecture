using CleanArchitecture.WebApp.Controllers.Bases;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.WebApp.Controllers.Identity
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return Ok();
        }

        [HttpGet]
        public IActionResult CreateCall()
        {
            return Ok();
        }
    }
}

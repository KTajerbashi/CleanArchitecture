using Domain.Library.Entities.PRD;
using Microsoft.AspNetCore.Mvc;

namespace EndPoint_WebApi.Controllers
{
    [Route("aps/Home")]
    [ApiController]
    public class HomeController : Controller
    {
        /// <summary>
        /// Index of Home Controller
        /// </summary>
        /// <remarks>Awesomeness!</remarks>
        /// <response code="200">Product created</response>
        /// <response code="400">Product has missing/invalid values</response>
        /// <response code="500">Oops! Can't create your product right now</response>
        [HttpGet("index")]
        [ProducesResponseType(typeof(Product), 200)]
        [ProducesResponseType(typeof(IDictionary<string, string>), 400)]
        [ProducesResponseType(500)]
        public IActionResult Index()
        {
            return View();
        }
    }
}

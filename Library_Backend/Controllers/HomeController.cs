using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EndPoint_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly ILogger<HomeController> _logger;
        public HomeController(ILogger<HomeController> logger)
        {

            _logger = logger;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Okay");
        }
        [HttpPut]
        public IActionResult Put()
        {
            return Ok("Okay");
        }
        [HttpDelete]
        public IActionResult Delete()
        {
            return Ok("Okay");
        }
        [HttpPost]
        public IActionResult Post()
        {
            return Ok("Okay");
        }
    }
}

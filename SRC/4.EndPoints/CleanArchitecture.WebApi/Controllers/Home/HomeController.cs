using CleanArchitecture.WebApi.BaseEndPoints;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.WebApi.Controllers.Home;

public class HomeController : BaseController
{
    private readonly ILogger<HomeController> _logger;
    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    [HttpGet("Index")]
    public Task<IActionResult> Index()
    {
        return OkResultAsync("Index => HomeController");
    }

}


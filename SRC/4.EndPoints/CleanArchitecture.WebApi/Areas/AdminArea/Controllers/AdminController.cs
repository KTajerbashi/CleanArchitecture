using CleanArchitecture.WebApi.BaseEndPoints;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.WebApi.Areas.AdminArea.Controllers;

public class AdminController : BaseController
{
    [HttpGet("Index")]
    public IActionResult Index()
    {
        return View();
    }
}

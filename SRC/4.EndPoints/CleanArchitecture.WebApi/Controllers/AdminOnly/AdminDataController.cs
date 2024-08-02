using CleanArchitecture.WebApi.BaseEndPoints;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.WebApi.Controllers.AdminOnly;

[Authorize(Policy = "AdminOnly")]
public class AdminDataController : BaseController
{
    public AdminDataController()
    {

    }

    [HttpGet]
    public IActionResult Get()
    {
        return Content(User.Identity.Name);
    }
}

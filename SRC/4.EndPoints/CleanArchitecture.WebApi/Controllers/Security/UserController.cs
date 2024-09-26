using CleanArchitecture.WebApi.BaseEndPoints;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.WebApi.Controllers.Security;

public class UserController : BaseController
{
    public IActionResult Create()
    {
        return Ok();
    }
}

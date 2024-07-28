using CleanArchitecture.WebApi.BaseEndPoints;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.WebApi.Controllers.Security;

public class ValuesController : BaseController
{
    [HttpGet]
    [Authorize]
    public IActionResult Get()
    {
        return Ok(new { message = "Authorized access" });
    }
}

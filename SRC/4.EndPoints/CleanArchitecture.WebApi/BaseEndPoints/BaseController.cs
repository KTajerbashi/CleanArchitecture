using CleanArchitecture.WebApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace CleanArchitecture.WebApi.BaseEndPoints;

[Route("api/[controller]")]
[ApiController]
public abstract class BaseController : Controller
{
    public BaseController()
    {

    }

    
    public override OkObjectResult Ok([ActionResultObjectValue] object? value)
         => base.Ok(_JsonResult.Success(value ?? true));
}

[Authorize]
public abstract class AuthorizeController : BaseController
{

}
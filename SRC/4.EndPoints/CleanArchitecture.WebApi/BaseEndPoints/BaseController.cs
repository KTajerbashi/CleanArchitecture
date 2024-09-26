using CleanArchitecture.WebApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace CleanArchitecture.WebApi.BaseEndPoints;

[Route("api/[controller]")]
[ApiController]
public abstract class BaseController : Controller
{
    protected readonly ILogger Logger;
    public BaseController(ILogger logger)
    {
        Logger = logger;
    }


    public override OkObjectResult Ok([ActionResultObjectValue] object? value)
         => base.Ok(_JsonResult.Success(value ?? true));
}

[Authorize]
public abstract class AuthorizeController : BaseController
{
    protected AuthorizeController(ILogger logger) : base(logger)
    {
    }
}
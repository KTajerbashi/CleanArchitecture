using CleanArchitecture.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace CleanArchitecture.WebApi.BaseEndPoints;

[Route("api/[controller]")]
[ApiController]
public abstract class BaseController : Controller
{
    protected readonly ILogger<BaseController> Logger;
    public BaseController(ILogger<BaseController> logger)
    {
        Logger = logger;
    }


    public override OkObjectResult Ok([ActionResultObjectValue] object? value)
         => base.Ok(_JsonResult.Success(value ?? true));
}

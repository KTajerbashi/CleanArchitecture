using CleanArchitecture.Application.BaseApplication.Models.Command;
using CleanArchitecture.Application.BaseApplication.Models.Query;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.WebApi.BaseEndPoints;

[Route("api/[controller]")]
[ApiController]
public abstract class BaseController : Controller
{
    public BaseController()
    {
        
    }
}

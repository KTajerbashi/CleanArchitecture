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

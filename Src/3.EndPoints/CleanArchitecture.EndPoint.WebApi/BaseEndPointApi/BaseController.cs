using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.EndPoint.WebApi.BaseEndPointApi;

[ApiController]
[Route("[controller]")]
public abstract class BaseController : Controller
{

}

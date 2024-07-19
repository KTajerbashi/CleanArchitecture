using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.WebApi.BaseEndPoints;

[Route("api/[controller]")]
[ApiController]
public abstract class BaseController : Controller
{
    public BaseController()
    {

    }

    public async Task<IActionResult> OkResultAsync<T>(T model)
    {
        return await Task.FromResult(Ok(model));
    }
}

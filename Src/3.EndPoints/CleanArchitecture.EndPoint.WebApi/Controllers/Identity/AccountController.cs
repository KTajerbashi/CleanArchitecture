using CleanArchitecture.EndPoint.WebApi.Models;

namespace CleanArchitecture.EndPoint.WebApi.Controllers.Identity;

public class AccountController : BaseController
{

    [HttpPost("Register")]
    public async Task<IActionResult> Register(RegisterRequest parameter)
    {
        await Task.CompletedTask;
        return Ok(parameter);
    }

    [HttpDelete("Remove")]
    public async Task<IActionResult> Remove()
    {
        await Task.CompletedTask;
        return Ok("Removed");
    }

    [HttpPut("DisActive")]
    public async Task<IActionResult> DisActive()
    {
        await Task.CompletedTask;
        return Ok("DisActive");
    }

    [HttpGet("Profile")]
    public async Task<IActionResult> Profile()
    {
        await Task.CompletedTask;
        return Ok("Profile");
    }
}

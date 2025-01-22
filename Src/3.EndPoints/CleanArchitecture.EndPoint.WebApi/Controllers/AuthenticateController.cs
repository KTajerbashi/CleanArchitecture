using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.EndPoint.WebApi.Controllers;

public class AuthenticateController : BaseController
{
    [HttpPost("Login")]
    public async Task<IActionResult> Login()
    {
        await Task.CompletedTask;
        return Ok("Login");
    }

    [HttpPost("Signin")]
    public async Task<IActionResult> Signin()
    {
        await Task.CompletedTask;
        return Ok("Signin");
    }

    [HttpGet("SignOut")]
    public async Task<IActionResult> SignOut()
    {
        await Task.CompletedTask;
        return Ok("SignOut");
    }

    [HttpPut("DisActive")]
    public async Task<IActionResult> DisActive()
    {
        await Task.CompletedTask;
        return Ok("DisActive");
    }
}
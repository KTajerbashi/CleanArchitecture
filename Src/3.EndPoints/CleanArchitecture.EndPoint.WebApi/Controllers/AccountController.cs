using CleanArchitecture.EndPoint.WebApi.BaseEndPointApi;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.EndPoint.WebApi.Controllers;

public class AccountController : AuthController
{
    [HttpPost("Register")]
    public async Task<IActionResult> Register()
    {
        await Task.CompletedTask;
        return Ok("Register");
    }

   
}

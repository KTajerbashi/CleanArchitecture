using CleanArchitecture.Core.Application.Library.Identity.Repositories;
using CleanArchitecture.Core.Application.Library.UseCases.Security.UserHandlers.RegisterUser;
using CleanArchitecture.EndPoint.WebApi.Common.Controllers;
using CleanArchitecture.Infra.SqlServer.Library.Identity.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.EndPoint.WebApi.Controllers;

public class UserManagerController : AuthController
{
    private readonly UserManager<UserEntity> _userManager;
    public UserManagerController(IMediator mediator, UserManager<UserEntity> userManager) : base(mediator)
    {
        _userManager = userManager;
    }

    [HttpGet("RealAllUsers")]
    public async Task<IActionResult> RealAllUsers()
    {
        return Ok(_userManager.Users.ToList());
    }


}

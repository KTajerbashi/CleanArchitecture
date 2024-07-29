using CleanArchitecture.Domain.Security.Entities;
using CleanArchitecture.WebApi.BaseEndPoints;
using CleanArchitecture.WebApi.Models;
using CleanArchitecture.WebApi.UserManagement.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.WebApi.Controllers.Security;

public class RoleController : BaseController
{
    private readonly IIdentityService _identityService;

    public RoleController(IIdentityService identityService)
    {
        _identityService = identityService;
    }

    [HttpPost("create")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> CreateRole([FromBody] RoleModel model)
    {
        var role = new RoleEntity { Name = model.RoleName };
        var result = await _identityService.RoleManager.CreateAsync(role);

        if (result.Succeeded)
        {
            return Ok();
        }

        return BadRequest(result.Errors);
    }

    [HttpPost("assign")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> AssignRole([FromBody] UserRoleModel model)
    {
        var user = await _identityService.UserManager.FindByNameAsync(model.Username);
        if (user == null)
        {
            return NotFound();
        }

        var result = await _identityService.UserManager.AddToRoleAsync(user, model.RoleName);

        if (result.Succeeded)
        {
            return Ok();
        }

        return BadRequest(result.Errors);
    }
}

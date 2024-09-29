using CleanArchitecture.Application.Repositories.Security.User.Model.DTOs;
using CleanArchitecture.Application.Repositories.Security.User.Repository;
using CleanArchitecture.WebApi.BaseEndPoints;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.WebApi.Controllers.Security;

//public class UserController : AuthorizeController
public class UserController : BaseController
{
    private readonly IUserRepository _userRepository;
    public UserController(ILogger<UserController> logger, IUserRepository userRepository) : base(logger)
    {
        _userRepository = userRepository;
    }

    /// <summary>
    /// Create User in System
    /// </summary>
    /// <param name="model"></param>
    /// <returns>Key of Record</returns>
    /// POST : api/User
    [HttpPost]
    public async Task<IActionResult> Create(UserDTO model)
    {
        return Ok(await _userRepository.AddOrUpdateAsync(model));
    }
}

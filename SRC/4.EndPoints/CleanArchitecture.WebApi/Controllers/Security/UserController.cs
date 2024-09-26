using CleanArchitecture.WebApi.BaseEndPoints;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.WebApi.Controllers.Security;

//public class UserController : AuthorizeController
public class UserController : BaseController
{
    public UserController(ILogger logger) : base(logger)
    {
    }

    /// <summary>
    /// Create User in System
    /// </summary>
    /// <returns>Key of Record</returns>
    /// POST : api/User
    [HttpPost]
    public IActionResult Create()
    {
        Logger.LogInformation("Create User");
        return Ok("");
    }
}

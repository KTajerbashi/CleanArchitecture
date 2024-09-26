using CleanArchitecture.WebApi.BaseEndPoints;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.WebApi.Controllers.Security;

//public class UserController : AuthorizeController
public class UserController : BaseController
{
    /// <summary>
    /// Create User in System
    /// </summary>
    /// <returns>Key of Record</returns>
    /// POST : api/User
    [HttpPost]
    public IActionResult Create()
    {
        return Ok("");
    }
}

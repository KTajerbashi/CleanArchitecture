using CleanArchitecture.WebApi.BaseEndPoints;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.WebApi.Controllers.UserOnly;



[Authorize(Policy = "UserOnly")]
public class UserDataController:BaseController
{
    public UserDataController()
    {
        
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Content(User.Identity.Name);
    }
}

using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using CleanArchitecture.Application.Repositories.Security.User.Model.DTOs;

namespace CleanArchitecture.WebApi.Attributes;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public class AuthorizeAttribute : Attribute, IAuthorizationFilter
{
    public void OnAuthorization(AuthorizationFilterContext context)
    {
        var user = (UserDTO?)context.HttpContext.Items["User"];
        if (user == null)
        {
            context.Result = new JsonResult(new { message = "Unauthorized" }) { StatusCode = StatusCodes.Status401Unauthorized };
        }
    }
}

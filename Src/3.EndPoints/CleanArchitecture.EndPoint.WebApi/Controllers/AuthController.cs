using Microsoft.AspNetCore.Authorization;

namespace CleanArchitecture.EndPoint.WebApi.Controllers;
[Authorize]
public abstract class AuthController : BaseController
{

}

using Microsoft.AspNetCore.Authorization;

namespace CleanArchitecture.WebApi.BaseEndPoints;

[Authorize]
public abstract class AuthorizeController : BaseController
{
    protected AuthorizeController(ILogger<AuthorizeController> logger) : base(logger)
    {
    }
}
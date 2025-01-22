using Microsoft.AspNetCore.Authorization;

namespace CleanArchitecture.EndPoint.WebApi.BaseEndPointApi;
[Authorize]
public abstract class AuthController : BaseController
{

}

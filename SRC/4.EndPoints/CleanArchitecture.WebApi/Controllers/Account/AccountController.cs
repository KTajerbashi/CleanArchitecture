using CleanArchitecture.WebApi.BaseEndPoints;
using CleanArchitecture.WebApi.UserManagement.Repositories;

namespace CleanArchitecture.WebApi.Controllers.Account;
public class AccountController : BaseController
{
    private readonly IIdentityService _identityService;
    public AccountController(IIdentityService identityService)
    {
        _identityService = identityService;
    }

}

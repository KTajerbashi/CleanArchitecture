namespace CleanArchitecture.EndPoint.WebApi.Controllers;

public class UserManagerController : AuthController
{
    private readonly UserManager<UserEntity> _userManager;
    public UserManagerController(IMediator mediator, UserManager<UserEntity> userManager) : base(mediator)
    {
        _userManager = userManager;
    }

    [HttpGet("RealAllUsers")]
    public async Task<IActionResult> RealAllUsers()
    {
        return Ok(_userManager.Users.ToList());
    }


}

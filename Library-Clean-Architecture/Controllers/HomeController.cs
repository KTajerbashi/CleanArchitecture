using Application.Library.Service;
using Microsoft.AspNetCore.Mvc;

namespace Library_Clean_Architecture
{
    [Route("[controller]/[action]")]
    public class HomeController : Controller
    {

        private readonly IGetUsersService _usersService;
        private readonly IRegisterUserService _registerUserService;
        private readonly IGetRolesService _getRolesService;
        public HomeController(
            IGetUsersService usersService,
            IRegisterUserService registerUserService,
            IGetRolesService getRolesService
            ) : base()
        {
            _usersService = usersService;
            _registerUserService = registerUserService;
            _getRolesService = getRolesService;

        }

        public IActionResult Index()
        {
            return View();
        }
    }
}

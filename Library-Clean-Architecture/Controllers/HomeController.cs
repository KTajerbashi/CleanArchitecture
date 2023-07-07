using Application.Library.Service;
using Library_Clean_Architecture.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Library_Clean_Architecture.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IGetUsersService _usersService;
        private readonly IRegisterUserService _registerUserService;
        private readonly IGetRolesService _getRolesService;

        //public HomeController(
        //    IGetUsersService usersService,
        //    IRegisterUserService registerUserService,
        //    IGetRolesService getRolesService,
        //    ILogger<HomeController> logger
        //    )
        //{
        //    _usersService = usersService;
        //    _registerUserService = registerUserService;
        //    _getRolesService = getRolesService;
        //    _logger = logger;

        //}
        public HomeController(
            ILogger<HomeController> logger,
            IGetUsersService usersService,
            IRegisterUserService registerUserService,
            IGetRolesService getRolesService
            )
        {
            _logger = logger;
            _usersService = usersService;
            _getRolesService = getRolesService;
            _registerUserService = registerUserService;

        }

        public IActionResult Index()
        {
            ViewBag.Roles = _getRolesService.Execute();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
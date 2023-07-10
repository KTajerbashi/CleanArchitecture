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
        private readonly IRemoveUserService _removeUserService;

        public HomeController(
            ILogger<HomeController> logger,
            IGetUsersService usersService,
            IRegisterUserService registerUserService,
            IGetRolesService getRolesService,
            IRemoveUserService removeUserService
            )
        {
            _logger = logger;
            _usersService = usersService;
            _getRolesService = getRolesService;
            _registerUserService = registerUserService;
            _removeUserService = removeUserService;

        }

        public IActionResult Index()
        {
            ViewBag.Roles = _getRolesService.Execute();
            ViewBag.User = User.Identity.Name;
            ViewBag.DatsSource = _usersService.Execute(new RequestGetUsers
            {
                SearchKey = ""
            });
            return View();
        }
        [HttpPost]
        public IActionResult Create(string Name, string Family, string Email, long RoleId, string Username, string Password)
        {
            var result = _registerUserService.Execute(new RequestRegisterUserDto
            {
                Name = Name,
                Family = Family,
                Email = Email,
                Username = Username,
                Password = Password,
                Roles = new List<RolesInRegisterUserDto>()
                {
                    new RolesInRegisterUserDto
                    {
                        Id=RoleId
                    }
                }

            });
            return RedirectToAction("Index");
        }

        public IActionResult Remove(long id)
        {
            var result = _removeUserService.RemoveUser(id);
            return RedirectToAction("Index");
            //return Json(result);
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
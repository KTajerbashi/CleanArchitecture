using Application.Library.Interfaces.Patterns;
using Application.Library.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Library_Clean_Architecture.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class UsersController : Controller
    {
        private readonly IUserFacad _userServices;
        public UsersController(IUserFacad userServices)
        {
            _userServices = userServices;
        }


        public IActionResult Index(string serchkey, int page = 1)
        {
            return View(_userServices.GetUsersService.Execute(new RequestGetUserDTO
            {
                Page = page,
                SearchKey = serchkey,
            }));
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Roles = new SelectList(_userServices.GetRolesService.Execute().Data, "ID", "Title");
            return View();
        }


        [HttpPost]
        public IActionResult Create(string Email, string Name, string Family, string Username, long RoleId, string Password, string RePassword)
        {
            var result = _userServices.RegisterUserService.Execute(new RequestRegisterUserDto
            {
                Email = Email,
                Username = Username,
                Name = Name,
                Family = Family,
                Roles = new List<RolesInRegisterUserDto>()
                   {
                        new RolesInRegisterUserDto
                        {
                             Id= RoleId
                        }
                   },
                Password = Password,
                RePasword = RePassword,
            });
            return Json(result);
        }

        [HttpPost]
        public IActionResult Delete(long UserId)
        {
            return Json(_userServices.RemoveUserService.RemoveUser(UserId));
        }

        [HttpPost]
        public IActionResult UserSatusChange(long UserId)
        {
            return Json(_userServices.UserSatusChangeService.Execute(UserId));
        }

        [HttpPost]
        public IActionResult Edit(long UserId, string Name)
        {
            return Json(_userServices.EditUserService.Execute(new RequestEdituserDto
            {
                Name = Name,
                UserId = UserId,
            }));
        }

    }
}

using Library.Application;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Library.Endpoint.Site.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly IGetUsersServices _usersServices;
        private readonly IGetRolesServices _getRolesServices;
        public UserController(IGetUsersServices usersServices,IGetRolesServices getRolesServices)
        {
            _usersServices = usersServices;
            _getRolesServices= getRolesServices;
        }

        public IActionResult Index(string searchKey,int page=1)
        {
            return View(_usersServices.Execute(new RequestGetUserDto
            {
                SearchKey = searchKey,
                Page = page
            }));
        }

        [HttpGet]
        public IActionResult Create()
        {
            //  Id => Value : Name => Text
            ViewBag.Roles = new SelectList(_getRolesServices.Execute().Data,"Id","Name");
            //  این داده را به سمت ویو ارسال میکنیم
            return View();
        }

        [HttpPost]
        public IActionResult Create(string name)
        {
            return View();
        }
    }
}

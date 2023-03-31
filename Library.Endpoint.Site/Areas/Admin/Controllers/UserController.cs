using Library.Application;
using Microsoft.AspNetCore.Mvc;

namespace Library.Endpoint.Site.Areas.Admin.Controllers
{
    public class UserController : Controller
    {
        private readonly IGetUsersServices _usersServices;
        public UserController(IGetUsersServices usersServices)
        {
            _usersServices = usersServices;
        }

        [Area("Admin")]
        public IActionResult Index(string searchKey,int page=1)
        {
            return View(_usersServices.Execute(new RequestGetUserDto
            {
                SearchKey = searchKey,
                Page = page
            }));
        }
    }
}

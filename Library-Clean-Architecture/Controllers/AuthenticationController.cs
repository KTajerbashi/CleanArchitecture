using Application.Library.Service;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Text.RegularExpressions;



namespace Library_Clean_Architecture.Controllers
{
    public class AuthenticationController : Controller
    {
        private readonly IUserLoginServices _userLoginServices;
        private readonly IRegisterUserService _registerUserServices;
        public AuthenticationController(
            IUserLoginServices userLoginServices,
            IRegisterUserService registerUserService
            )
        {
            _userLoginServices = userLoginServices;
            _registerUserServices = registerUserService;
        }
        public ActionResult Signin(string ReturnUrl = "/")
        {
            ViewBag.ReturnUrl = ReturnUrl;
            return View();
        }

        [HttpPost]
        public ActionResult Signin(string Email, string Password, string Url = "/")
        {
            var signupResult = _userLoginServices.Execute(Email,Password);
            if (signupResult.IsSuccess)
            {
                var claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.NameIdentifier,signupResult.Data.UserId.ToString()),
                    new Claim(ClaimTypes.Email,Email),
                    new Claim(ClaimTypes.Name,signupResult.Data.Name.ToString()),
                    new Claim(ClaimTypes.Role,signupResult.Data.Role.ToString()),
                };
                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principle = new ClaimsPrincipal(identity);
                var properties = new AuthenticationProperties()
                {
                    IsPersistent= true,
                    ExpiresUtc= DateTime.Now.AddDays(5)
                };
                HttpContext.SignInAsync(principle, properties);
            }
            return Json(signupResult);
        }
        public IActionResult SignOut()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }

    }
}

using Application.Library.ModelBase;
using Application.Library.Repositories.SEC.UserRepositories.Models.DTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Persistance.Library.EF.Identity;

namespace WEB_API.Controllers.AUT
{
    [ApiController]
    [Route("service/[controller]")]
    public class AccountController : ControllerBase
    {
        private UserManager<AppUser> _userManager;
        private SignInManager<AppUser> _signInManager;
        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        /// <summary>
        /// Login User
        /// </summary>
        /// <remarks>Awesomeness!</remarks>
        /// <response code="200">User Login</response>
        /// <response code="400">User has missing/invalid values</response>
        /// <response code="500">Oops! Can't Login your User right now</response>
        [HttpGet("Login")]
        [ProducesResponseType(typeof(UserDTO), 200)]
        [ProducesResponseType(typeof(IDictionary<string, string>), 400)]
        [ProducesResponseType(500)]
        public async Task<ResultPublicDTO<UserDTO>> Login(UserDTO user, string returnUrl)
        {
            await Task.Delay(1000);
            if (ModelState.IsValid)
            {
                var data = new AppUser();
                var tryCount = data.AccessFailedCount;
                bool lockUser = tryCount >= 5;
                if (data == null)
                {
                    return new ResultPublicDTO<UserDTO>
                    {
                        Count = 0,
                        Message = " ",
                        Result = user
                    };
                }
                await _signInManager.SignOutAsync();
                Microsoft.AspNetCore.Identity.SignInResult result =
                    await _signInManager.PasswordSignInAsync(
                        data,
                        user.Password,
                        false,  //  IsRemember Me
                        lockUser   //  Count Of try to login
                        );
                if (result.Succeeded)
                {
                    return new ResultPublicDTO<UserDTO>
                    {
                        Count = 0,
                        Message = " ",
                        Result = user
                    };
                }
            }
            return new ResultPublicDTO<UserDTO>
            {
                Count = 0,
                Message = " ",
                Result = user
            };

        }

        /// <summary>
        /// SignIn User
        /// </summary>
        /// <remarks>Awesomeness!</remarks>
        /// <response code="200">User SignIn</response>
        /// <response code="400">User has missing/invalid values</response>
        /// <response code="500">Oops! Can't SignIn your User right now</response>
        [HttpGet("SignIn")]
        [ProducesResponseType(typeof(UserDTO), 200)]
        [ProducesResponseType(typeof(IDictionary<string, string>), 400)]
        [ProducesResponseType(500)]
        public async Task<ResultPublicDTO<UserDTO>> SignIn(UserDTO user, string returnUrl)
        {
            await Task.Delay(1000);
            if (ModelState.IsValid)
            {
                return new ResultPublicDTO<UserDTO>
                {
                    Count = 0,
                    Message = " ",
                    Result = user
                };
            }
            return new ResultPublicDTO<UserDTO>
            {
                Count = 0,
                Message = " ",
                Result = user
            };

        }

    }
}

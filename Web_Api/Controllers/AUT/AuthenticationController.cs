using Application.Library.BaseModel.BaseDTO;
using Application.Library.Repositories.SEC.UserRepositories.Models.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace Web_Api.Controllers.AUT
{
    [ApiController]
    [Route("[controller]")]
    public class AuthenticationController : Controller
    {

        [Route("Login")]
        [HttpPost]
        [PasswordPropertyText]
        public async Task<Result<bool>> Login(string username, string password)
        {
            await Task.Delay(1);
            return new Result<bool>
            {
                Data = true,
                Message = "",
                Status = true,
            };
        }
        [Route("Logout")]
        [HttpGet]
        public async Task<Result<bool>> Logout(Guid guid)
        {
            await Task.Delay(1);
            return new Result<bool>
            {
                Data = true,
                Message = "",
                Status = true,
            };
        }
        [Route("Signup")]
        [HttpPost]
        public async Task<Result<bool>> Signup(UserDTO user)
        {
            await Task.Delay(1);
            return new Result<bool>
            {
                Data = true,
                Message = "",
                Status = true,
            };
        }
    }
}

using Application.Library.BaseModel.BaseDTO;
using Application.Library.Repositories.SEC.UserRepositories.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Web_Api.Controllers.AUT
{
    public class AuthenticationController : Controller
    {
     
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
        public async Task<Result<bool>> LogOut(Guid guid)
        {
            await Task.Delay(1);
            return new Result<bool>
            {
                Data = true,
                Message = "",
                Status = true,
            };
        }
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

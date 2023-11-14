using Application.Library.BaseModel.BaseDTO;
using Application.Library.Repositories.SEC.UserRepositories.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Web_Api.Controllers.SEC
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class UserController : ControllerBase
    {
        //[HttpGet("Create")]
        [HttpGet(Name = "Create")]
        public async Task<Result<bool>> Create(UserDTO user)
        {
            await Task.Delay(1);
            return new Result<bool>
            {

            };
        }
    }
}

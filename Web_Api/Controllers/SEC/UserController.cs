using Application.Library.BaseModel.BaseDTO;
using Application.Library.Repositories.SEC.UserRepositories.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Web_Api.Controllers.SEC
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        public async Task<Result<bool>> Create(UserDTO user)
        {
            await Task.Delay(1);
            return new Result<bool>
            {

            };
        }
    }
}

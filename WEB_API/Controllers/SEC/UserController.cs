using Application.Library.ModelBase;
using Application.Library.Repositories.SEC.UserRepositories.Models.DTOs;
using Domain.Library.Entities.PRD;
using Microsoft.AspNetCore.Mvc;
using NLog;

namespace WEB_API.Controllers.SEC
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
        /// <summary>
        /// Get All People
        /// </summary>
        /// <remarks>Awesomeness!</remarks>
        /// <response code="200">Product created</response>
        /// <response code="400">Product has missing/invalid values</response>
        /// <response code="500">Oops! Can't create your product right now</response>
        [HttpGet("GetAll")]
        [ProducesResponseType(typeof(Product), 200)]
        [ProducesResponseType(typeof(IDictionary<string, string>), 400)]
        [ProducesResponseType(500)]
        public async Task<ResultPublicDTO<UserDTO>> Create()
        {
            await Task.Delay(1000);
            _logger.Info("متد فوق فراخوانی شد");
            return new ResultPublicDTO<UserDTO>
            {
                Count = 0,
                Message = string.Empty,
                Result = new UserDTO
                {
                    ID = 1,
                    Guid = Guid.NewGuid(),
                    Key = "",
                }
            };
        }
    }
}

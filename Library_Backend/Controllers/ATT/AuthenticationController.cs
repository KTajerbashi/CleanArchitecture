using Common.Library;
using Domain.Library.Entities.PRD;
using EndPoint_WebApi.Attributes.FilterAttributes;
using EndPoint_WebApi.Filters.ActionFilters;
using Microsoft.AspNetCore.Mvc;

namespace EndPoint_WebApi.Controllers.ATT
{
    [Route("auth/Home")]
    [ApiController]
    public class AuthenticationController : Controller
    {

        public AuthenticationController()
        {
            
        }
        /// <summary>
        /// Authentication Login
        /// </summary>
        /// <remarks>Awesomeness!</remarks>
        /// <response code="200">Login created</response>
        /// <response code="400">Login has missing/invalid values</response>
        /// <response code="500">Oops! Can't create your Login right now</response>
        [HttpGet("Login")]
        [ProducesResponseType(typeof(string), 200)]
        [ProducesResponseType(typeof(IDictionary<string, string>), 400)]
        [ProducesResponseType(500)]
        [AuthorizationFilterAction]
        public ResultDTO<string> Login()
        {
            return new ResultDTO<string>()
            {
                Success = true,
                Data = "شما وارد نرم افزار شدید",
                Message = "شما با موفقیت وارد شدید دوست عزیز"
            };
        }



        /// <summary>
        /// Authentication SignUp
        /// </summary>
        /// <remarks>Awesomeness!</remarks>
        /// <response code="200">SignUp created</response>
        /// <response code="400">SignUp has missing/invalid values</response>
        /// <response code="500">Oops! Can't create your SignUp right now</response>
        [HttpGet("SignUp")]
        [ProducesResponseType(typeof(string), 200)]
        [ProducesResponseType(typeof(IDictionary<string, string>), 400)]
        [ProducesResponseType(500)]
        [AuthorizationFilter]
        public ResultDTO<string> SignUp()
        {
            return new ResultDTO<string>()
            {
                Success = true,
                Data = "شما در ثبت سیستم نرم افزار شدید",
                Message = "شما با موفقیت ثبت نام شدید دوست عزیز"
            };
        }
    }
}

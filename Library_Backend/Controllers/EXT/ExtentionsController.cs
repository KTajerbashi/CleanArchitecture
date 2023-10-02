using Common.Library.Utilities;
using Domain.Library.Entities.PRD;
using Infrastructure.Library.Extentions;
using Microsoft.AspNetCore.Mvc;

namespace EndPoint_WebApi.Controllers.EXT
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExtentionsController : ControllerBase
    {
        private readonly UpTimeService _upTimeService;
        public ExtentionsController(UpTimeService upTimeService)
        {
            _upTimeService = upTimeService;
        }
        /// <summary>
        /// Get Uptime in millisecond
        /// </summary>
        /// <remarks>Awesomeness!</remarks>
        /// <response code="200">Uptime created</response>
        /// <response code="400">Uptime has missing/invalid values</response>
        /// <response code="500">Oops! Can't create your Uptime right now</response>
        [HttpGet("UpTime")]
        [ProducesResponseType(typeof(Product), 200)]
        [ProducesResponseType(typeof(IDictionary<string, string>), 400)]
        [ProducesResponseType(500)]
        public string UpTime() => (@$"UpTime Milli Second : {_upTimeService.GetUpTime}\n");


        /// <summary>
        /// Get GetPersion Date
        /// </summary>
        /// <remarks>Awesomeness!</remarks>
        /// <response code="200">Uptime created</response>
        /// <response code="400">Uptime has missing/invalid values</response>
        /// <response code="500">Oops! Can't create your Uptime right now</response>
        [HttpGet("GetPersion")]
        [ProducesResponseType(typeof(DateTime), 200)]
        [ProducesResponseType(typeof(IDictionary<string, string>), 400)]
        [ProducesResponseType(500)]
        public string GetPersion() => (@$"Date in Persion is {ConvertDate.GetPersionDate(DateTime.Now)}");


        /// <summary>
        /// Get GetPersion Short Date
        /// </summary>
        /// <remarks>Awesomeness!</remarks>
        /// <response code="200">Uptime created</response>
        /// <response code="400">Uptime has missing/invalid values</response>
        /// <response code="500">Oops! Can't create your Uptime right now</response>
        [HttpGet("GetPersionShortDate")]
        [ProducesResponseType(typeof(DateTime), 200)]
        [ProducesResponseType(typeof(IDictionary<string, string>), 400)]
        [ProducesResponseType(500)]
        public string GetPersionShortDate() => (@$"Short Date in Persion is {ConvertDate.GetShortDate(DateTime.Now)}");

        /// <summary>
        /// Get GetTime
        /// </summary>
        /// <remarks>Awesomeness!</remarks>
        /// <response code="200">Uptime created</response>
        /// <response code="400">Uptime has missing/invalid values</response>
        /// <response code="500">Oops! Can't create your Uptime right now</response>
        [HttpGet("GetPersionTime")]
        [ProducesResponseType(typeof(DateTime), 200)]
        [ProducesResponseType(typeof(IDictionary<string, string>), 400)]
        [ProducesResponseType(500)]
        public string GetPersionTime() => (@$"Time in Persion is {ConvertDate.GetTime(DateTime.Now)}");

        /// <summary>
        /// Get Gregorian Date
        /// </summary>
        /// <remarks>Awesomeness!</remarks>
        /// <response code="200">Uptime created</response>
        /// <response code="400">Uptime has missing/invalid values</response>
        /// <response code="500">Oops! Can't create your Uptime right now</response>
        [HttpGet("GetGregorianDate")]
        [ProducesResponseType(typeof(DateTime), 200)]
        [ProducesResponseType(typeof(IDictionary<string, string>), 400)]
        [ProducesResponseType(500)]
        public string GetGregorianDate() => (@$"Time in Persion is {ConvertDate.GetGregorianDate(ConvertDate.GetPersionDate(DateTime.Now.AddYears(2)))}");

        /// <summary>
        /// Get Gregorian Time Date
        /// </summary>
        /// <remarks>Awesomeness!</remarks>
        /// <response code="200">Uptime created</response>
        /// <response code="400">Uptime has missing/invalid values</response>
        /// <response code="500">Oops! Can't create your Uptime right now</response>
        [HttpGet("GetGregorianTime")]
        [ProducesResponseType(typeof(DateTime), 200)]
        [ProducesResponseType(typeof(IDictionary<string, string>), 400)]
        [ProducesResponseType(500)]
        public string GetGregorianTime() => (@$"Time in Persion is {ConvertDate.GetGregorianTime(ConvertDate.GetPersionDate(DateTime.Now.AddYears(2)))}");



    }
}

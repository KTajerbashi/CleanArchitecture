using Application.Library.Interfaces.Patterns.FacadPatterns;
using Application.Library.Interfaces.SEC.Person.DTOs;
using Common.Library;
using Domain.Library.Entities.PRD;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace EndPoint_WebApi.Controllers.SEC
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IFacadRepositories _service;
        public PersonController(IFacadRepositories service)
        {
            _service = service;
        }

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
        public async Task<ResultDTO<IEnumerable<PersonDTO>>> GetAll() => await _service.PersonGetAllRepository.Execute();

        /// <summary>
        /// Get Person By Id
        /// </summary>
        /// <remarks>Awesomeness!</remarks>
        /// <response code="200">Product created</response>
        /// <response code="400">Product has missing/invalid values</response>
        /// <response code="500">Oops! Can't create your product right now</response>
        [HttpGet("GetById")]
        [ProducesResponseType(typeof(Product), 200)]
        [ProducesResponseType(typeof(IDictionary<string, string>), 400)]
        [ProducesResponseType(500)]
        public async Task<ResultDTO<PersonDTO>> GetById(long Id) => await _service.PersonGetByIDRepository.Execute(Id);

        /// <summary>
        /// Get Person By Guid
        /// </summary>
        /// <remarks>Awesomeness!</remarks>
        /// <response code="200">Product created</response>
        /// <response code="400">Product has missing/invalid values</response>
        /// <response code="500">Oops! Can't create your product right now</response>
        [HttpGet("GetByGuid")]
        [ProducesResponseType(typeof(Product), 200)]
        [ProducesResponseType(typeof(IDictionary<string, string>), 400)]
        [ProducesResponseType(500)]
        public async Task<ResultDTO<PersonDTO>> GetByGuid(Guid guid) => await _service.PersonGetByGuidRepository.Execute(guid);

        /// <summary>
        /// Get Person By Name
        /// </summary>
        /// <remarks>Awesomeness!</remarks>
        /// <response code="200">Product created</response>
        /// <response code="400">Product has missing/invalid values</response>
        /// <response code="500">Oops! Can't create your product right now</response>
        [HttpGet("GetByName")]
        [ProducesResponseType(typeof(Product), 200)]
        [ProducesResponseType(typeof(IDictionary<string, string>), 400)]
        [ProducesResponseType(500)]
        public async Task<ResultDTO<PersonDTO>> GetByName(string name) => await _service.PersonGetByNameRepository.Execute(name);

        /// <summary>
        /// Create Person
        /// </summary>
        /// <remarks>Awesomeness!</remarks>
        /// <response code="200">Product created</response>
        /// <response code="400">Product has missing/invalid values</response>
        /// <response code="500">Oops! Can't create your product right now</response>
        [HttpPost("Create")]
        [ProducesResponseType(typeof(Product), 200)]
        [ProducesResponseType(typeof(IDictionary<string, string>), 400)]
        [ProducesResponseType(500)]
        public async Task<ResultDTO<long>> Create(PersonDTO model) => await _service.PersonCreateRepository.Execute(model);

        /// <summary>
        /// Change Person Entity State
        /// </summary>
        /// <remarks>Awesomeness!</remarks>
        /// <response code="200">Product created</response>
        /// <response code="400">Product has missing/invalid values</response>
        /// <response code="500">Oops! Can't create your product right now</response>
        [HttpPut("Change")]
        [ProducesResponseType(typeof(Product), 200)]
        [ProducesResponseType(typeof(IDictionary<string, string>), 400)]
        [ProducesResponseType(500)]
        public async Task<ResultDTO<long>> Change(PersonDTO model) => await _service.PersonChangeRepository.Execute(model);

        /// <summary>
        /// Update Person
        /// </summary>
        /// <remarks>Awesomeness!</remarks>
        /// <response code="200">Product created</response>
        /// <response code="400">Product has missing/invalid values</response>
        /// <response code="500">Oops! Can't create your product right now</response>
        [HttpPut("Update")]
        [ProducesResponseType(typeof(Product), 200)]
        [ProducesResponseType(typeof(IDictionary<string, string>), 400)]
        [ProducesResponseType(500)]
        public async Task<ResultDTO<long>> Update(PersonDTO model) => await _service.PersonUpdateRepository.Execute(model);

        /// <summary>
        /// Delete Person
        /// </summary>
        /// <remarks>Awesomeness!</remarks>
        /// <response code="200">Product created</response>
        /// <response code="400">Product has missing/invalid values</response>
        /// <response code="500">Oops! Can't create your product right now</response>
        [HttpDelete("Delete")]
        [ProducesResponseType(typeof(Product), 200)]
        [ProducesResponseType(typeof(IDictionary<string, string>), 400)]
        [ProducesResponseType(500)]
        public async Task<ResultDTO<long>> Delete(string guid) => await _service.PersonDeleteRepository.Execute(Guid.Parse(guid));
    }
}

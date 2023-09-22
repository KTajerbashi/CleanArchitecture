using Application.Library.Interfaces.Patterns.FacadPatterns;
using Application.Library.Interfaces.SEC.Person.DTOs;
using Common.Library;
using Microsoft.AspNetCore.Mvc;

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



        [HttpGet("GetAll")]
        public async Task<ResultDTO<IEnumerable<PersonDTO>>> GetAll()
        {
            return await _service.PersonGetAllRepository.Execute();
        }


        [HttpGet("GetById")]
        public async Task<ResultDTO<PersonDTO>> GetById(long Id)
        {
            return await _service.PersonGetByIDRepository.Execute(Id);
        }


        [HttpGet("GetByGuid")]
        public async Task<ResultDTO<PersonDTO>> GetByGuid(Guid guid)
        {
            return await _service.PersonGetByGuidRepository.Execute(guid);
        }


        [HttpGet("GetByName")]
        public async Task<ResultDTO<PersonDTO>> GetByName(string name)
        {
            return await _service.PersonGetByNameRepository.Execute(name);
        }


        [HttpPost("Create")]
        public async Task<ResultDTO<long>> Create(PersonDTO model)
        {
            var result = await _service.PersonCreateRepository.Execute(model);
            _service.SaveChangesAsync();
            return result;
        }


        [HttpPut("Change")]
        public async Task<ResultDTO<long>> Change(PersonDTO model)
        {
            var result = await _service.PersonChangeRepository.Execute(model);
            _service.SaveChangesAsync();
            return result;
        }


        [HttpPut("Update")]
        public async Task<ResultDTO<long>> Update(PersonDTO model)
        {
            var result = await _service.PersonUpdateRepository.Execute(model);
            _service.SaveChangesAsync();
            return result;
        }



        [HttpDelete("Delete")]
        public async Task<ResultDTO<long>> Delete(string guid)
        {
            var result = await _service.PersonDeleteRepository.Execute(Guid.Parse(guid));
            _service.SaveChangesAsync();
            return result;

        }
    }
}

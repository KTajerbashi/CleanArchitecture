using Application.Library.Interfaces;
using Application.Library.Interfaces.SEC.Person.DTOs;
using Application.Library.Interfaces.SEC.Person.Queries;
using AutoMapper;
using Common.Library;
using Microsoft.EntityFrameworkCore;
using Persistance.Library.MapperProfile;

namespace Persistance.Library.ServiceRepository.Services.SEC.Person.Queries
{
    public class PersonGetByNameService : IPersonGetByNameRepository
    {
        private readonly IDatabaseContext _context;
        private readonly IMapper _mapper;
        public PersonGetByNameService(IDatabaseContext context, IMapper mapper)
        {
            //var config =AutoMapperConfiguration.InitializeAutomapper();
            _context = context;
            _mapper = mapper;
        }
        public async Task<ResultDTO<PersonDTO>> Execute(object name)
        {
            var data = await _context.People.Where(x => x.Name.Equals(name.ToString())).SingleAsync();
            var result = _mapper.Map<PersonDTO>(data);
            return RequestResult<PersonDTO>.Ok(result);
        }
    }
}

using Application.Library.Interfaces;
using Application.Library.Interfaces.SEC.Person.DTOs;
using Application.Library.Interfaces.SEC.Person.Queries;
using AutoMapper;
using Common.Library;
using Microsoft.EntityFrameworkCore;
using Persistance.Library.MapperProfile;

namespace Persistance.Library.ServiceRepository.Services.SEC.Person.Queries
{
    public class PersonGetByIDService : IPersonGetByIDRepository
    {
        private readonly IDatabaseContext _context;
        private readonly IMapper _mapper;
        public PersonGetByIDService(IDatabaseContext context, IMapper mapper)
        {
            //var config =AutoMapperConfiguration.InitializeAutomapper();
            _context = context;
            _mapper = mapper;
        }
        public async Task<ResultDTO<PersonDTO>> Execute(object ID)
        {
            var data = await _context.People.FindAsync(ID);
            var result = _mapper.Map<PersonDTO>(data);
            return RequestResult<PersonDTO>.Ok(result);
        }
    }
}

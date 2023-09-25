using Application.Library.Interfaces;
using Application.Library.Interfaces.SEC.Person.DTOs;
using Application.Library.Interfaces.SEC.Person.Queries;
using AutoMapper;
using Common.Library;
using Domain.Library.Entities.SEC;
using Microsoft.EntityFrameworkCore;
using Persistance.Library.MapperProfile;

namespace Persistance.Library.ServiceRepository.Services
{
    public class PersonGetAllService : IPersonGetAllRepository
    {
        private readonly IDatabaseContext _context;
        private readonly IMapper _mapper;
        public PersonGetAllService(IDatabaseContext context, IMapper mapper)
        {
            //var config =AutoMapperConfiguration.InitializeAutomapper();
            _context = context;
            _mapper = mapper;
        }
        public async Task<ResultDTO<IEnumerable<PersonDTO>>> Execute()
        {
            var data = await _context.People.Skip(0).Take(20).ToListAsync();
            var result = _mapper.Map<IEnumerable<PersonDTO>>(data);
            if (data.Count > 0)
            {
                return RequestResult<IEnumerable<PersonDTO>>.Ok(result);
            }
            return RequestResult<IEnumerable<PersonDTO>>.NotFound(result);
        }
    }
}

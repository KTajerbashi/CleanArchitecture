using Application.Library.Interfaces;
using Application.Library.Interfaces.SEC.Person.DTOs;
using Application.Library.Interfaces.SEC.Person.Queries;
using AutoMapper;
using Common.Library;
using Microsoft.EntityFrameworkCore;
using Persistance.Library.MapperProfile;

namespace Persistance.Library.ServiceRepository.Services.SEC.Person.Queries
{
    public class PersonGetByGuidService : IPersonGetByGuidRepository
    {
        private readonly IDatabaseContext _context;
        private readonly IMapper _mapper;
        public PersonGetByGuidService(IDatabaseContext context, IMapper mapper)
        {
            var config =AutoMapperConfiguration.InitializeAutomapper();
            _context = context;
            _mapper = config;
        }
        public async Task<ResultDTO<PersonDTO>> Execute(Guid guid)
        {
            var model = await _context.People.Where(x => x.Guid == guid).SingleAsync();
            var result = _mapper.Map<PersonDTO>(model);
            if (model == null)
            {
                return RequestResult<PersonDTO>.NotFound(result);
            }
            return RequestResult<PersonDTO>.Ok(result);
        }
    }
}

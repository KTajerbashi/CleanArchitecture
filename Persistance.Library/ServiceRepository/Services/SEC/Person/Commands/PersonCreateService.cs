using Application.Library.Interfaces;
using Application.Library.Interfaces.SEC.Person.Commands;
using Application.Library.Interfaces.SEC.Person.DTOs;
using AutoMapper;
using Common.Library;
using Domain.Library.Entities.SEC;
using Persistance.Library.MapperProfile;

namespace Persistance.Library.ServiceRepository.Services
{
    public class PersonCreateService : IPersonCreateRepository
    {
        private readonly IDatabaseContext _context;
        private readonly IMapper _mapper;
        public PersonCreateService(IDatabaseContext context, IMapper mapper)
        {
            var config =AutoMapperConfiguration.InitializeAutomapper();
            _context = context;
            _mapper = config;
        }
        public async Task<ResultDTO<long>> Execute(PersonDTO model)
        {
            var entity = _mapper.Map<Person>(model);
            entity.Guid = Guid.NewGuid();
            var data = await _context.People.AddAsync(entity);
            return new ResultDTO<long>()
            {
                Success = true,
                Message = " با موققیت انجام شد ",
                Data = data.Entity.ID
            };
        }
    }
}

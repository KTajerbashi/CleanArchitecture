using Application.Library.Interfaces;
using Application.Library.Interfaces.SEC.Person.Commands;
using Application.Library.Interfaces.SEC.Person.DTOs;
using AutoMapper;
using Common.Library;
using Domain.Library.Entities.SEC;
using Microsoft.EntityFrameworkCore;
using Persistance.Library.MapperProfile;

namespace Persistance.Library.ServiceRepository.Services
{
    public class PersonChangeService : IPersonChangeRepository
    {
        private readonly IDatabaseContext _context;
        private readonly IMapper _mapper;
        public PersonChangeService(IDatabaseContext context, IMapper mapper)
        {
            var config =AutoMapperConfiguration.InitializeAutomapper();
            _context = context;
            _mapper = config;
        }
        public async Task<ResultDTO<long>> Execute(PersonDTO model)
        {
            var result = _mapper.Map<Person>(model);
            var data = _context.People.Update(result);
            await Task.Delay(1000);
            return new ResultDTO<long>()
            {
                Message = " با موققیت انجام شد ",
                Success = true,
                Data = data.Entity.ID
            };
        }
    }
}

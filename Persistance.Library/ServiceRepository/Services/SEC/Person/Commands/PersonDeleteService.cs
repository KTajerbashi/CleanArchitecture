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
    public class PersonDeleteService : IPersonDeleteRepository
    {
        private readonly IDatabaseContext _context;
        private readonly IMapper _mapper;
        public PersonDeleteService(IDatabaseContext context, IMapper mapper)
        {
            var config =AutoMapperConfiguration.InitializeAutomapper();
            _context = context;
            _mapper = config;
        }
        public async Task<ResultDTO<long>> Execute(Guid guid)
        {
            var model = _context.People.Find(guid);
            var entity = _mapper.Map<Person>(model);
            var data = _context.People.Remove(entity);
            await Task.Delay(1000);
            return new ResultDTO<long>()
            {
                Success = true,
                Message = " با موققیت انجام شد ",
                Data = data.Entity.ID
            };
        }
    }
}

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
            //var config =AutoMapperConfiguration.InitializeAutomapper();
            _context = context;
            _mapper = mapper;
        }
        public async Task<ResultDTO<long>> Execute(Guid guid)
        {
            var model = _context.People.Where(x => x.Guid == guid).FirstOrDefault();
            if (model == null)
            {
                return RequestResult<long>.NotFound(model.ID);
            }
            var entity = _mapper.Map<Person>(model);
            var data = _context.People.Find(entity.ID);
            data.IsDeleted = true;
            await _context.SaveChangesAsync();
            return RequestResult<long>.Ok(model.ID);
        }
    }
}

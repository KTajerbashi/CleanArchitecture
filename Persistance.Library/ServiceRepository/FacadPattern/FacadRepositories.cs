using Application.Library.Interfaces;
using Application.Library.Interfaces.Patterns.FacadPatterns;
using Application.Library.Interfaces.Patterns.UnitOfWork;
using Application.Library.Interfaces.SEC.Person.Commands;
using Application.Library.Interfaces.SEC.Person.Queries;
using AutoMapper;
using Infrastructure.Library.Extentions;
using Persistance.Library.ServiceRepository.Services;
using Persistance.Library.ServiceRepository.Services.SEC.Person.Queries;

namespace Persistance.Library.ServiceRepository.FacadPattern
{
    public class FacadRepositories : IFacadRepositories
    {
        private readonly IDatabaseContext _context;
        private readonly IMapper _mapper;
        public FacadRepositories(IDatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        private IPersonChangeRepository _personChangeRepository;
        public IPersonChangeRepository PersonChangeRepository
        {
            get
            {
                return _personChangeRepository = _personChangeRepository ?? new PersonChangeService(_context,_mapper);
            }
        }
        private IPersonCreateRepository _personCreateRepository;
        public IPersonCreateRepository PersonCreateRepository
        {
            get
            {
                return _personCreateRepository = _personCreateRepository ?? new PersonCreateService(_context, _mapper);
            }
        }
        private IPersonDeleteRepository _personDeleteRepository;
        public IPersonDeleteRepository PersonDeleteRepository
        {
            get
            {
                return _personDeleteRepository = _personDeleteRepository ?? new PersonDeleteService(_context, _mapper);
            }
        }

        private IPersonUpdateRepository _personUpdateRepository;
        public IPersonUpdateRepository PersonUpdateRepository
        {
            get
            {
                return _personUpdateRepository = _personUpdateRepository ?? new PersonUpdateService(_context, _mapper);
            }
        }

        public IPersonGetAllRepository _personGetAllRepository;
        public IPersonGetAllRepository PersonGetAllRepository
        {
            get
            {
                return _personGetAllRepository = _personGetAllRepository ?? new PersonGetAllService(_context, _mapper);
            }
        }

        public IPersonGetByGuidRepository _personGetByGuidRepository;
        public IPersonGetByGuidRepository PersonGetByGuidRepository
        {
            get
            {
                return _personGetByGuidRepository = _personGetByGuidRepository ?? new PersonGetByGuidService(_context, _mapper);
            }
        }
        public IPersonGetByIDRepository _personGetByIDRepository;
        public IPersonGetByIDRepository PersonGetByIDRepository
        {
            get
            {
                return _personGetByIDRepository = _personGetByIDRepository ?? new PersonGetByIDService(_context, _mapper);
            }
        }
        public IPersonGetByNameRepository _personGetByNameRepository;
        public IPersonGetByNameRepository PersonGetByNameRepository
        {
            get
            {
                return _personGetByNameRepository = _personGetByNameRepository ?? new PersonGetByNameService(_context, _mapper);
            }
        }

        
        public void BeginTransaction()
        {
            throw new NotImplementedException();
        }

        public void SaveChangesAsync()
        {
            _context.SaveChanges();
        }

        public void CommitTransaction()
        {
            throw new NotImplementedException();
        }

        public void Rollback()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}

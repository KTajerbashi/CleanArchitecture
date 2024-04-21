using AutoMapper;
using CleanArchitecture.Application.Library.Patterns.UnitOfWork;
using CleanArchitecture.Persistence.Library.DataContext;

namespace CleanArchitecture.Infrastructure.Library.Patterns.UnitOfWorks
{
    public interface IUnitOfWorkFactory
    {
        IUnitOfWork BeginTransAction();
    }
    public class UnitOfWorkFactory : IUnitOfWorkFactory
    {
        private readonly IMapper _mapper;
        private readonly DBContextApplication _context;

        public UnitOfWorkFactory(DBContextApplication context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IUnitOfWork BeginTransAction()
        {
            throw new NotImplementedException();
        }
    }
}

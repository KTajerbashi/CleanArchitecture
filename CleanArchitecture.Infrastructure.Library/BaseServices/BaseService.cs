using CleanArchitecture.Application.Library.BaseRepositories;
using CleanArchitecture.Persistence.Library.DataContext;

namespace CleanArchitecture.Infrastructure.Library.BaseServices
{
    public abstract class BaseService : IBaseRepository
    {
        protected readonly DBContextApplication _context;
        public BaseService(DBContextApplication context)
        {
            _context = context;
        }
    }
}

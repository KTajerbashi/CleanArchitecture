using Application.Library.BaseRepositories;
using AutoMapper;
using CleanArchitecture.Infrastructure.Library.DatabaseContextApplication.EF;
using CleanArchitecture.Infrastructure.Library.ORM.Dapper;

namespace CleanArchitecture.Infrastructure.Library.BaseServices
{
    public abstract class BaseService : IBaseRepository
    {
        protected readonly DBContextApplication _context;
        protected readonly IMapper _mapper;
        protected readonly IDapperRepository _dapper;
        public BaseService(DBContextApplication context, IMapper mapper, IDapperRepository dapper)
        {
            _context = context;
            _mapper = mapper;
            _dapper = dapper;
        }
    }
}

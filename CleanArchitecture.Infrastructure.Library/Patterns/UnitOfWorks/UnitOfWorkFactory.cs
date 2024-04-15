using Application.Library.Patterns.UnitOfWork;
using AutoMapper;
using CleanArchitecture.Infrastructure.Library.DatabaseContextApplication.EF;
using CleanArchitecture.Infrastructure.Library.ORM.Dapper;
using Infrastructure.Library.Patterns.UnitOfWorks;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infrastructure.Library.Patterns.UnitOfWorks
{
    public interface IUnitOfWorkFactory
    {
        IUnitOfWork BeginTransAction();
    }
    public class UnitOfWorkFactory : IUnitOfWorkFactory
    {
        private readonly DBContextApplication _context;
        private readonly IMapper _mapper;
        private readonly IDapperRepository _dapper;
        public UnitOfWorkFactory(DBContextApplication context, IDapperRepository dapper)
        {
            _context = context;
            _dapper = dapper;
        }
        public IUnitOfWork BeginTransAction()
        {
            return new UnitOfWork(_context, _mapper, _dapper);
        }
    }
}

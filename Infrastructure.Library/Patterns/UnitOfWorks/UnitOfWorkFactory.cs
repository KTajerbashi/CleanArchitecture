using Application.Library.Patterns.UnitOfWork;
using AutoMapper;
using Infrastructure.Library.DatabaseContextApplication.EF;
using Infrastructure.Library.ORM.Dapper;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Library.Patterns.UnitOfWorks
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

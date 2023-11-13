using Application.Library.Patterns.UnitOfWork;
using AutoMapper;
using Infrastructure.Library.DatabaseContextApplication.EF;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Library.Patterns.UnitOfWorks
{
    public interface IUnitOfWorkFactory
    {
        IUnitOfWork BeginTransAction();
    }
    public class UnitOfWorkFactory : IUnitOfWorkFactory
    {
        private DBContextApplication _context;
        private readonly IMapper _mapper;
        public UnitOfWorkFactory(DBContextApplication _context)
        {
            this._context = _context;
        }
        public IUnitOfWork BeginTransAction()
        {
            return new UnitOfWork(_context, _mapper);
        }
    }
}

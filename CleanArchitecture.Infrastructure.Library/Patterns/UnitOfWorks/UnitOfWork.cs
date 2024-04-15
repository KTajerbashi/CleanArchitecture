using Application.Library.Patterns.Facad.BUS;
using Application.Library.Patterns.Facad.RPT;
using Application.Library.Patterns.Facad.SEC;
using Application.Library.Patterns.UnitOfWork;
using AutoMapper;
using CleanArchitecture.Infrastructure.Library.DatabaseContextApplication.EF;
using CleanArchitecture.Infrastructure.Library.ORM.Dapper;
using CleanArchitecture.Infrastructure.Library.Patterns.Facad.BUS;
using CleanArchitecture.Infrastructure.Library.Patterns.Facad.RPT;
using CleanArchitecture.Infrastructure.Library.Patterns.Facad.SEC;

namespace CleanArchitecture.Infrastructure.Library.Patterns.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DBContextApplication _context;
        private readonly IMapper _mapper;
        private readonly IDapperRepository _dapper;
        public UnitOfWork(DBContextApplication context, IMapper mapper, IDapperRepository dapper)
        {
            _context = context;
            _mapper = mapper;
            _dapper = dapper;
        }

        private ProductFacad _productFacad;
        public IProductFacad ProductFacad
        {
            get
            {
                return _productFacad = _productFacad ?? new ProductFacad(_context, _mapper, _dapper);
            }
        }

        private UserFacad _userFacad;
        public IUserFacad UsertFacad
        {
            get
            {
                return _userFacad = _userFacad ?? new UserFacad(_context, _mapper);
            }
        }

        public ReportFacad _reportFacad;
        public IReportFacad ReportFacad
        {
            get
            {
                return _reportFacad = _reportFacad ?? new ReportFacad(_context, _mapper);
            }
        }
        public void BeginTransAction()
        {
            _context.Database.BeginTransaction();
        }

        public void Commit()
        {
            _context.Database.CommitTransaction();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public void RollBack()
        {
            _context.Database.RollbackTransaction();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}

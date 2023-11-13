﻿using Application.Library.Patterns.Facad.BUS;
using Application.Library.Patterns.Facad.RPT;
using Application.Library.Patterns.Facad.SEC;
using Application.Library.Patterns.UnitOfWork;
using AutoMapper;
using Infrastructure.Library.DatabaseContextApplication.EF;
using Infrastructure.Library.Patterns.Facad.BUS;
using Infrastructure.Library.Patterns.Facad.RPT;
using Infrastructure.Library.Patterns.Facad.SEC;

namespace Infrastructure.Library.Patterns.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DBContextApplication _context;
        private readonly IMapper _mapper;
        public UnitOfWork(DBContextApplication _context, IMapper mapper)
        {
            this._context = _context;
            _mapper = mapper;
        }

        private ProductFacad _productFacad;
        public IProductFacad ProductFacad
        {
            get
            {
                return _productFacad = _productFacad ?? new ProductFacad(_context, _mapper);
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

using Application.Library.Patterns.Facad.RPT;
using Application.Library.Repositories.RPT.ProductReports.Queries;
using AutoMapper;
using Infrastructure.Library.DatabaseContextApplication.EF;
using Infrastructure.Library.Services.RPT.ProductReports.Queries;

namespace Infrastructure.Library.Patterns.Facad.RPT
{
    public class ReportFacad : IReportFacad
    {
        private readonly DBContextApplication _context;
        private readonly IMapper _mapper;
        public ReportFacad(DBContextApplication context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        private ReportProductService _reportProductService;
        public IReportProductRepository ReportProductRepository
        {
            get
            {
                return _reportProductService = _reportProductService ?? new ReportProductService(_context,_mapper);
            }
        }

    }
}

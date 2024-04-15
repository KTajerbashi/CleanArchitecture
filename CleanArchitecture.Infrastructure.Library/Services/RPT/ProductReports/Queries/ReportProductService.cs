using Application.Library.Repositories.RPT.ProductReports.Queries;
using AutoMapper;
using CleanArchitecture.Infrastructure.Library.DatabaseContextApplication.EF;

namespace CleanArchitecture.Infrastructure.Library.Services.RPT.ProductReports.Queries
{
    public class ReportProductService : IReportProductRepository
    {
        private readonly DBContextApplication _context;
        private readonly IMapper _mapper;
        public ReportProductService(DBContextApplication context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
    }
}

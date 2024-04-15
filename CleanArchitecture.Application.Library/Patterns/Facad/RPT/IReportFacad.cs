using CleanArchitecture.Application.Library.Repositories.RPT.ProductReports.Queries;

namespace CleanArchitecture.Application.Library.Patterns.Facad.RPT
{
    public interface IReportFacad
    {
        IReportProductRepository ReportProductRepository { get; }
    }
}

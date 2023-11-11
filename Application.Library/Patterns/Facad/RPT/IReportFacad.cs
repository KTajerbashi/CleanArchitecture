using Application.Library.Repositories.RPT.ProductReports.Queries;

namespace Application.Library.Patterns.Facad.RPT
{
    public interface IReportFacad
    {
        IReportProductRepository ReportProductRepository { get; }
    }
}

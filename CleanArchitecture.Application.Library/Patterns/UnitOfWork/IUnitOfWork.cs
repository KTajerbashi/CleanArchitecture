using CleanArchitecture.Application.Library.Patterns.Facad.BUS;
using CleanArchitecture.Application.Library.Patterns.Facad.RPT;
using CleanArchitecture.Application.Library.Patterns.Facad.SEC;

namespace CleanArchitecture.Application.Library.Patterns.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
        void BeginTransAction();
        void SaveChanges();
        void RollBack();

        IProductFacad ProductFacad { get; }
        IUserFacad UsertFacad { get; }
        IReportFacad ReportFacad { get; }
    }
}

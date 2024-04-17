using CleanArchitecture.Application.Library.Patterns.Facad.SEC;

namespace CleanArchitecture.Application.Library.Patterns.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
        void BeginTransAction();
        void SaveChanges();
        void RollBack();

        IUserFacad UserFacad { get; }
    }
}

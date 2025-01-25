namespace CleanArchitecture.Core.Application.Library.BaseCoreApplication.PatternUnitOfWork;

public interface IUnitOfWork
{
    Task CommitTransactionAsync();
    void CommitTransaction();
    
    Task BeginTransactionAsync();
    void BeginTransaction();
    
    Task<int> SaveChangeAsync();
    int SaveChange();
    
    Task RollbackTransactionAsync();
    void RollbackTransaction();
}

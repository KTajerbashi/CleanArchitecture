using CleanArchitecture.Core.Application.Providers.Scrutor;

namespace CleanArchitecture.Core.Application.Common.Patterns.UnitOfWorkPattern;

public interface IUnitOfWork : IScopeLifeTime
{
    Task<int> SaveChangeAsync(CancellationToken cancellationToken = default);
    int SaveChange();

    void BeginTransaction();
    Task BeginTransactionAsync();

    void CommitTransaction();
    Task CommitTransactionAsync();

    void RollbackTransaction();
    Task RollbackTransactionAsync();
}

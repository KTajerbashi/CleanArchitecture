using CleanArchitecture.Application.BaseApplication.Patterns;
using CleanArchitecture.Infrastructure.BaseInfrastructure.BaseDatabaseContexts;

namespace CleanArchitecture.Infrastructure.BaseInfrastructure.Pattern;

public abstract class UnitOfWork<TContext>(TContext context) : IUnitOfWork
    where TContext : BaseDatabaseContext
{

    protected TContext Context = context;

    //protected UnitOfWork(TContext context) => Context = context;

    public void BeginTransaction() => Context.Database.BeginTransaction();

    public void BeginTransactionAsync() => Context.Database.BeginTransactionAsync();

    public void CommitTransaction() => Context.Database.CommitTransaction();

    public void CommitTransactionAsync() => Context.Database.CommitTransactionAsync();

    public void Dispose() => Context.Dispose();

    public void RollbackTransaction() => Context.Database.RollbackTransaction();

    public void RollbackTransactionAsync() => Context.Database.RollbackTransactionAsync();

    public int SaveChange() => Context.SaveChanges();

    public async Task<int> SaveChangeAsync() => await Context.SaveChangesAsync();
}

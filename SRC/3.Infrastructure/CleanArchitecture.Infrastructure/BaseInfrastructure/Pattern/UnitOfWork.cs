using CleanArchitecture.Application.BaseApplication.Patterns;
using CleanArchitecture.Infrastructure.BaseInfrastructure.BaseDatabaseContexts;

namespace CleanArchitecture.Infrastructure.BaseInfrastructure.Pattern;

public abstract class UnitOfWork<TContext> : IUnitOfWork
    where TContext : BaseDatabaseContext
{

    protected TContext Context;

    protected UnitOfWork(TContext context)
    {
        Context = context;
    }

    public void BeginTransaction()
    {
        Context.Database.BeginTransaction();
    }

    public void BeginTransactionAsync()
    {
        Context.Database.BeginTransactionAsync();
    }

    public void CommitTransaction()
    {
        Context.Database.CommitTransaction();
    }

    public void CommitTransactionAsync()
    {
        Context.Database.CommitTransactionAsync();
    }

    public void RollbackTransaction()
    {
        Context.Database.RollbackTransaction();
    }

    public void RollbackTransactionAsync()
    {
        Context.Database.RollbackTransactionAsync();
    }

    public int SaveChange()
    {
        return Context.SaveChanges();
    }

    public async Task<int> SaveChangeAsync()
    {
        return await Context.SaveChangesAsync();
    }
}

using CleanArchitecture.Core.Application.Library.BaseCoreApplication.PatternUnitOfWork;
using CleanArchitecture.Infra.SqlServer.Library.BaseInfrastructure.DatabaseContext;

namespace CleanArchitecture.Infra.SqlServer.Library.BaseInfrastructure.PatternUnitOfWork;

public abstract class UnitOfWork<TContext> : IUnitOfWork
    where TContext : BaseDatabaseContext
{
    protected TContext Context;

    protected UnitOfWork(TContext context)
    {
        Context = context;
    }

    public void BeginTransaction()
        => Context.Database.BeginTransaction();

    public async Task BeginTransactionAsync()
        => await Context.Database.BeginTransactionAsync();


    public void CommitTransaction()
        => Context.Database.CommitTransaction();


    public async Task CommitTransactionAsync()
           => await Context.Database.CommitTransactionAsync();


    public void RollbackTransaction()
          => Context.Database.RollbackTransaction();


    public async Task RollbackTransactionAsync()
        => await Context.Database.RollbackTransactionAsync();


    public int SaveChange()
        => Context.SaveChanges();


    public async Task<int> SaveChangeAsync()
        => await Context.SaveChangesAsync();

}

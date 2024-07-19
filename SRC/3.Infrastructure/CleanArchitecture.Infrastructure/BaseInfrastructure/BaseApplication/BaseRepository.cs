using CleanArchitecture.Application.BaseApplication.Models.DTOs;
using CleanArchitecture.Application.BaseApplication.Models.Views;
using CleanArchitecture.Application.BaseApplication.Repositories;
using CleanArchitecture.Domain.BasesDomain;
using CleanArchitecture.Infrastructure.DatabaseContext;
using System.Linq.Expressions;

namespace CleanArchitecture.Infrastructure.BaseInfrastructure.BaseApplication;

public abstract class BaseRepository<TContext, TEntity, TDTO, TView, TId> : IBaseRepository<TEntity, TDTO,TView, TId>
    where TContext : CleanArchitectureDb
    where TEntity : IEntity<TId>
    where TDTO : IModelDTO<TId>
    where TView : IModelView
    where TId : struct,
          IComparable,
          IComparable<TId>,
          IConvertible,
          IEquatable<TId>,
          IFormattable
{
    protected readonly TContext context;

    protected BaseRepository(TContext context)
    {
        this.context = context;
    }

    public bool AddOrUpdate(TDTO entity)
    {
        throw new NotImplementedException();
    }

    public Task AddOrUpdateAsync(TDTO entity)
    {
        throw new NotImplementedException();
    }

    public void BeginTransaction()
    {
        throw new NotImplementedException();
    }

    public void BeginTransactionAsync()
    {
        throw new NotImplementedException();
    }

    public void CommitTransaction()
    {
        throw new NotImplementedException();
    }

    public void CommitTransactionAsync()
    {
        throw new NotImplementedException();
    }

    public bool Delete(TId id)
    {
        throw new NotImplementedException();
    }

    public bool Delete(TDTO entity)
    {
        throw new NotImplementedException();
    }

    public bool DeleteGraph(TId id)
    {
        throw new NotImplementedException();
    }

    public bool Exists(Expression<Func<TDTO, bool>> expression)
    {
        throw new NotImplementedException();
    }

    public Task<bool> ExistsAsync(Expression<Func<TDTO, bool>> expression)
    {
        throw new NotImplementedException();
    }

    public TView Get(TId id)
    {
        throw new NotImplementedException();
    }

    public TView Get(Guid Guid)
    {
        throw new NotImplementedException();
    }

    public TView Get()
    {
        throw new NotImplementedException();
    }

    public Task<TView> GetAsync(TId id)
    {
        throw new NotImplementedException();
    }

    public Task<TView> GetAsync(Guid Guid)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<TView>> GetAsync()
    {
        throw new NotImplementedException();
    }

    public TView GetGraph(TId id)
    {
        throw new NotImplementedException();
    }

    public TView GetGraph(Guid Guid)
    {
        throw new NotImplementedException();
    }

    public Task<TView> GetGraphAsync(TId id)
    {
        throw new NotImplementedException();
    }

    public Task<TView> GetGraphAsync(Guid Guid)
    {
        throw new NotImplementedException();
    }

    public bool Insert(TDTO entity)
    {
        throw new NotImplementedException();
    }

    public Task InsertAsync(TDTO entity)
    {
        throw new NotImplementedException();
    }

    public void RollbackTransaction()
    {
        throw new NotImplementedException();
    }

    public void RollbackTransactionAsync()
    {
        throw new NotImplementedException();
    }

    public int SaveChange()
    {
        throw new NotImplementedException();
    }

    public Task<int> SaveChangeAsync()
    {
        throw new NotImplementedException();
    }

    public bool Update(TDTO entity)
    {
        throw new NotImplementedException();
    }

    public bool Update(TDTO entity, TId id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(TDTO entity)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(TDTO entity, TId id)
    {
        throw new NotImplementedException();
    }
}

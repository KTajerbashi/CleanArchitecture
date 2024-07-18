using CleanArchitecture.Application.BaseApplication.Repositories;
using CleanArchitecture.Domain.BasesDomain;
using CleanArchitecture.Domain.BasesDomain.ValueObjects.BusinessId;
using CleanArchitecture.Infrastructure.DatabaseContext;
using System.Linq.Expressions;

namespace CleanArchitecture.Infrastructure.BaseInfrastructure.BaseApplication;

public abstract class BaseRepository<TContext, TEntity, TId> : IBaseRepository<TEntity, TId>
    where TContext : CleanArchitectureDb
    where TEntity : IEntity<TId>
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

    public void AddOrUpdate(TEntity entity)
    {
        throw new NotImplementedException();
    }

    public Task AddOrUpdateAsync(TEntity entity)
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

    public void Delete(TId id)
    {
        throw new NotImplementedException();
    }

    public void Delete(TEntity entity)
    {
        throw new NotImplementedException();
    }

    public void DeleteGraph(TId id)
    {
        throw new NotImplementedException();
    }

    public bool Exists(Expression<Func<TEntity, bool>> expression)
    {
        throw new NotImplementedException();
    }

    public Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> expression)
    {
        throw new NotImplementedException();
    }

    public TEntity Get(TId id)
    {
        throw new NotImplementedException();
    }

    public TEntity Get(BusinessId businessId)
    {
        throw new NotImplementedException();
    }

    public Task<TEntity> GetAsync(TId id)
    {
        throw new NotImplementedException();
    }

    public Task<TEntity> GetAsync(BusinessId businessId)
    {
        throw new NotImplementedException();
    }

    public TEntity GetGraph(TId id)
    {
        throw new NotImplementedException();
    }

    public TEntity GetGraph(BusinessId businessId)
    {
        throw new NotImplementedException();
    }

    public Task<TEntity> GetGraphAsync(TId id)
    {
        throw new NotImplementedException();
    }

    public Task<TEntity> GetGraphAsync(BusinessId businessId)
    {
        throw new NotImplementedException();
    }

    public void Insert(TEntity entity)
    {
        throw new NotImplementedException();
    }

    public Task InsertAsync(TEntity entity)
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

    public void Update(TEntity entity)
    {
        throw new NotImplementedException();
    }

    public void Update(TEntity entity, TId id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(TEntity entity)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(TEntity entity, TId id)
    {
        throw new NotImplementedException();
    }
}

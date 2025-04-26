using CleanArchitecture.Core.Application.Library.Common.Repository;
using CleanArchitecture.Core.Domain.Library.Common;

namespace CleanArchitecture.Infra.SqlServer.Library.Common.Repository;

public abstract class Repository<TEntity, TId> : IRepository<TEntity, TId>
    where TEntity : BaseAuditableEntity<TId>
    where TId : struct,
          IComparable,
          IComparable<TId>,
          IConvertible,
          IEquatable<TId>,
          IFormattable
{
    public TEntity Add(TEntity entity, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public void BeginTransaction()
    {
        throw new NotImplementedException();
    }

    public Task BeginTransactionAsync()
    {
        throw new NotImplementedException();
    }

    public void CommitTransaction()
    {
        throw new NotImplementedException();
    }

    public Task CommitTransactionAsync()
    {
        throw new NotImplementedException();
    }

    public TEntity Get(TId id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public TEntity Get(Guid entityId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public IReadOnlyCollection<TEntity> Get(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public TEntity GetAsNoTracking(TId id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public TEntity GetAsNoTracking(Guid entityId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<TEntity> GetAsNoTrackingAsync(TId id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<TEntity> GetAsNoTrackingAsync(Guid entityId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<TEntity> GetAsync(TId id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<TEntity> GetAsync(Guid entityId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<IReadOnlyCollection<TEntity>> GetAsync(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public bool Remove(TEntity entity, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public bool Remove(TId id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public bool Remove(Guid entityId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<bool> RemoveAsync(TEntity entity, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<bool> RemoveAsync(TId id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<bool> RemoveAsync(Guid entityId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public void RollbackTransaction()
    {
        throw new NotImplementedException();
    }

    public Task RollbackTransactionAsync()
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
}

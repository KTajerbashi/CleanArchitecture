using CleanArchitecture.Core.Application.Library.Common.Patterns.UnitOfWorkPattern;
using CleanArchitecture.Core.Domain.Library.Common;
using System.Linq.Expressions;

namespace CleanArchitecture.Core.Application.Library.Common.Repository;

public interface IRepository<TEntity, TId> : IUnitOfWork
    where TEntity : BaseAuditableEntity<TId>
    where TId : struct,
          IComparable,
          IComparable<TId>,
          IConvertible,
          IEquatable<TId>,
          IFormattable
{

    TEntity Add(TEntity entity, CancellationToken cancellationToken);
    Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken);

    bool Remove(TEntity entity, CancellationToken cancellationToken);
    Task<bool> RemoveAsync(TEntity entity, CancellationToken cancellationToken);

    bool Remove(TId id, CancellationToken cancellationToken);
    Task<bool> RemoveAsync(TId id, CancellationToken cancellationToken);

    bool Remove(Guid entityId, CancellationToken cancellationToken);
    Task<bool> RemoveAsync(Guid entityId, CancellationToken cancellationToken);

    TEntity Get(TId id, CancellationToken cancellationToken);
    Task<TEntity> GetAsync(TId id, CancellationToken cancellationToken);
    TEntity GetAsNoTracking(TId id, CancellationToken cancellationToken);
    Task<TEntity> GetAsNoTrackingAsync(TId id, CancellationToken cancellationToken);

    TEntity Get(Guid entityId, CancellationToken cancellationToken);
    Task<TEntity> GetAsync(Guid entityId, CancellationToken cancellationToken);
    TEntity GetAsNoTracking(Guid entityId, CancellationToken cancellationToken);
    Task<TEntity> GetAsNoTrackingAsync(Guid entityId, CancellationToken cancellationToken);

    IEnumerable<TEntity> Get(CancellationToken cancellationToken);
    Task<IEnumerable<TEntity>> GetAsync(CancellationToken cancellationToken);

    IQueryable<TEntity> GetAll();
    IQueryable<TEntity> GetAllAsNoTracking();
    IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
    Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default);
    bool Exists(Expression<Func<TEntity, bool>> predicate);
    Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default);



}

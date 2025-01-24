using CleanArchitecture.Core.Domain.Library.BaseCoreDomain;

namespace CleanArchitecture.Core.Application.Library.BaseCoreApplication;

public interface IBaseRepository<TEntity, TId> 
    where TEntity : AuditableEntity
    where TId : struct,
          IComparable,
          IComparable<TId>,
          IConvertible,
          IEquatable<TId>,
          IFormattable
{
    Task<TId> InsertAsync(TEntity entity,CancellationToken cancellation);
    Task DeleteAsync(TEntity entity,CancellationToken cancellation);
    Task DeleteAsync(TId id,CancellationToken cancellation);
    Task<TEntity> ReadAsync(TId id,CancellationToken cancellation);
    Task<IEnumerable<TEntity>> ReadAsync(CancellationToken cancellation);
}

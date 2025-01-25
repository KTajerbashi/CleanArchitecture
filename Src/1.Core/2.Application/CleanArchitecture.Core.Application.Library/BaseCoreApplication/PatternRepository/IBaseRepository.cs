using CleanArchitecture.Core.Application.Library.BaseCoreApplication.PatternUnitOfWork;
using CleanArchitecture.Core.Domain.Library.BaseCoreDomain;

namespace CleanArchitecture.Core.Application.Library.BaseCoreApplication.PatternRepository;

public interface IBaseRepository<TEntity, TId> : IUnitOfWork
    where TEntity : AuditableEntity
    where TId : struct,
          IComparable,
          IComparable<TId>,
          IConvertible,
          IEquatable<TId>,
          IFormattable
{
    Task<TId> InsertAsync(TEntity entity, CancellationToken cancellation);
    Task DeleteAsync(TEntity entity, CancellationToken cancellation);
    Task DeleteAsync(TId id, CancellationToken cancellation);
    Task<TEntity> ReadAsync(TId id, CancellationToken cancellation);
    Task<IEnumerable<TEntity>> ReadAsync(CancellationToken cancellation);
}

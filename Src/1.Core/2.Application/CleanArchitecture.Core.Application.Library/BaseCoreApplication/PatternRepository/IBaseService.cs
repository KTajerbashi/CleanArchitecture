using CleanArchitecture.Core.Domain.Library.BaseCoreDomain;

namespace CleanArchitecture.Core.Application.Library.BaseCoreApplication.PatternRepository;

public interface IBaseService<TEntity, TId>
    where TEntity : class, IAuditableEntity<TId>
    where TId : struct,
          IComparable,
          IComparable<TId>,
          IConvertible,
          IEquatable<TId>,
          IFormattable
{
}

using CleanArchitecture.Core.Application.Library.Common.Repository;
using CleanArchitecture.Core.Application.Library.Providers.Scrutor;
using CleanArchitecture.Core.Domain.Library.Common;

namespace CleanArchitecture.Core.Application.Library.Common.Service;

public interface IEntityService<TRepository,TEntity,TId> : IScopeLifeTime
    where TRepository : IRepository<TEntity, TId>
    where TEntity : BaseAuditableEntity<TId>
    where TId : struct,
          IComparable,
          IComparable<TId>,
          IConvertible,
          IEquatable<TId>,
          IFormattable
{
    
}

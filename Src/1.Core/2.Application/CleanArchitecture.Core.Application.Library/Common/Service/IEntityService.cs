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
    Task<TEntity> CreateAsync(TEntity entity);
    Task<TEntity> UpdateAsync(TEntity entity);
    Task<TEntity> DeleteAsync(EntityId entityId);
    Task<TEntity> DeleteAsync(TId id);
    Task<TEntity> GetAsync(TId id);
    Task<TEntity> GetAsync(EntityId entityId);
    Task<IEnumerable<TEntity>> GetAsync();
}

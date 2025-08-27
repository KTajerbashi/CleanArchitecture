using CleanArchitecture.Core.Application.Common.Repository;
using CleanArchitecture.Core.Application.Providers.Scrutor;
using CleanArchitecture.Core.Domain.Common;

namespace CleanArchitecture.Core.Application.Common.Service;

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

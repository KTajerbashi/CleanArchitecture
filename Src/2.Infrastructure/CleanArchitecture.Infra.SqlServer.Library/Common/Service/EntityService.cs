using CleanArchitecture.Core.Application.Library.Common.Service;

namespace CleanArchitecture.Infra.SqlServer.Library.Common.Service;

public abstract class EntityService<TRepository, TEntity, TId>
    : IEntityService<TRepository, TEntity, TId>
    where TRepository : IRepository<TEntity, TId>
    where TEntity : BaseAuditableEntity<TId>
    where TId : struct,
          IComparable,
          IComparable<TId>,
          IConvertible,
          IEquatable<TId>,
          IFormattable
{
    protected readonly TRepository Repository;

    protected EntityService(TRepository repository)
    {
        Repository = repository;
    }

    public virtual Task<TEntity> CreateAsync(TEntity entity)
    {
        throw new NotImplementedException();
    }

    public virtual Task<TEntity> DeleteAsync(EntityId entityId)
    {
        throw new NotImplementedException();
    }

    public virtual Task<TEntity> DeleteAsync(TId id)
    {
        throw new NotImplementedException();
    }

    public virtual Task<TEntity> GetAsync(TId id)
    {
        throw new NotImplementedException();
    }

    public virtual Task<TEntity> GetAsync(EntityId entityId)
    {
        throw new NotImplementedException();
    }

    public virtual Task<IEnumerable<TEntity>> GetAsync()
    {
        throw new NotImplementedException();
    }

    public virtual Task<TEntity> UpdateAsync(TEntity entity)
    {
        throw new NotImplementedException();
    }
}

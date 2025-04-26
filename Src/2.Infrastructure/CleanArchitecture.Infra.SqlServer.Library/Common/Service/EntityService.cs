using CleanArchitecture.Core.Application.Library.Common.Repository;
using CleanArchitecture.Core.Application.Library.Common.Service;
using CleanArchitecture.Core.Domain.Library.Common;

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

    public Task<TEntity> CreateAsync(TEntity entity)
    {
        throw new NotImplementedException();
    }

    public Task<TEntity> DeleteAsync(EntityId entityId)
    {
        throw new NotImplementedException();
    }

    public Task<TEntity> DeleteAsync(TId id)
    {
        throw new NotImplementedException();
    }

    public Task<TEntity> GetAsync(TId id)
    {
        throw new NotImplementedException();
    }

    public Task<TEntity> GetAsync(EntityId entityId)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<TEntity>> GetAsync()
    {
        throw new NotImplementedException();
    }

    public Task<TEntity> UpdateAsync(TEntity entity)
    {
        throw new NotImplementedException();
    }
}

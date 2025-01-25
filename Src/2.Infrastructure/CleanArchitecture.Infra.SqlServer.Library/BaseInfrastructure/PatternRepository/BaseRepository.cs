using CleanArchitecture.Core.Application.Library.BaseCoreApplication.PatternRepository;
using CleanArchitecture.Core.Domain.Library.BaseCoreDomain;
using CleanArchitecture.Infra.SqlServer.Library.BaseInfrastructure.PatternUnitOfWork;
using CleanArchitecture.Infra.SqlServer.Library.DatabaseContext;

namespace CleanArchitecture.Infra.SqlServer.Library.BaseInfrastructure.PatternRepository;

public abstract class BaseRepository<TEntity, TId> :
    UnitOfWork<ApplicationDatabase>, IBaseRepository<TEntity, TId>
    where TEntity : AuditableEntity
    where TId : struct,
          IComparable,
          IComparable<TId>,
          IConvertible,
          IEquatable<TId>,
          IFormattable
{
    protected BaseRepository(ApplicationDatabase context) : base(context)
    {
    }

    public Task DeleteAsync(TEntity entity, CancellationToken cancellation)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(TId id, CancellationToken cancellation)
    {
        throw new NotImplementedException();
    }

    public Task<TId> InsertAsync(TEntity entity, CancellationToken cancellation)
    {
        throw new NotImplementedException();
    }

    public Task<TEntity> ReadAsync(TId id, CancellationToken cancellation)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<TEntity>> ReadAsync(CancellationToken cancellation)
    {
        throw new NotImplementedException();
    }
}

public abstract class BaseService<TEntity, TId> : IBaseService<TEntity, TId>
    where TEntity : class, IAuditableEntity<TId>
    where TId : struct,
          IComparable,
          IComparable<TId>,
          IConvertible,
          IEquatable<TId>,
          IFormattable
{

}
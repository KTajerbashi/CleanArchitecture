using CleanArchitecture.Application.BaseApplication.Models.DTOs;
using CleanArchitecture.Application.BaseApplication.Models.Views;
using CleanArchitecture.Application.BaseApplication.Repositories;
using CleanArchitecture.Domain.BasesDomain;
using CleanArchitecture.Infrastructure.DatabaseContext;
using ObjectMapper.Abstraction;
using System.Linq.Expressions;

namespace CleanArchitecture.Infrastructure.BaseInfrastructure.BaseApplication;

public abstract class BaseRepository<TContext, TEntity, TDTO, TView, TId> : IBaseRepository<TEntity, TDTO,TView, TId>
    where TContext : CleanArchitectureDb
    where TEntity : IEntity<TId>
    where TDTO : IModelDTO<TId>
    where TView : IModelView
    where TId : struct,
          IComparable,
          IComparable<TId>,
          IConvertible,
          IEquatable<TId>,
          IFormattable
{
    protected readonly TContext context;
    protected readonly IMapperAdapter MapperFacad;
    protected BaseRepository(TContext context, IMapperAdapter mapperFacad)
    {
        this.context = context;
        MapperFacad = mapperFacad;
    }

    public virtual bool AddOrUpdate(TDTO entity)
    {
        throw new NotImplementedException();
    }

    public virtual Task AddOrUpdateAsync(TDTO entity)
    {
        throw new NotImplementedException();
    }

    public virtual void BeginTransaction()
    {
        throw new NotImplementedException();
    }

    public virtual void BeginTransactionAsync()
    {
        throw new NotImplementedException();
    }

    public virtual void CommitTransaction()
    {
        throw new NotImplementedException();
    }

    public virtual void CommitTransactionAsync()
    {
        throw new NotImplementedException();
    }

    public virtual bool Delete(TId id)
    {
        throw new NotImplementedException();
    }

    public virtual bool Delete(TDTO entity)
    {
        throw new NotImplementedException();
    }

    public virtual bool DeleteGraph(TId id)
    {
        throw new NotImplementedException();
    }

    public virtual bool Exists(Expression<Func<TDTO, bool>> expression)
    {
        throw new NotImplementedException();
    }

    public virtual Task<bool> ExistsAsync(Expression<Func<TDTO, bool>> expression)
    {
        throw new NotImplementedException();
    }

    public virtual TView Get(TId id)
    {
        throw new NotImplementedException();
    }

    public virtual TView Get(Guid Guid)
    {
        throw new NotImplementedException();
    }

    public virtual TView Get()
    {
        throw new NotImplementedException();
    }

    public virtual Task<TView> GetAsync(TId id)
    {
        throw new NotImplementedException();
    }

    public virtual Task<TView> GetAsync(Guid Guid)
    {
        throw new NotImplementedException();
    }

    public virtual Task<IEnumerable<TView>> GetAsync()
    {
        throw new NotImplementedException();
    }

    public virtual TView GetGraph(TId id)
    {
        throw new NotImplementedException();
    }

    public virtual TView GetGraph(Guid Guid)
    {
        throw new NotImplementedException();
    }

    public virtual Task<TView> GetGraphAsync(TId id)
    {
        throw new NotImplementedException();
    }

    public virtual Task<TView> GetGraphAsync(Guid Guid)
    {
        throw new NotImplementedException();
    }

    public virtual bool Insert(TDTO entity)
    {
        throw new NotImplementedException();
    }

    public virtual Task InsertAsync(TDTO entity)
    {
        throw new NotImplementedException();
    }

    public virtual void RollbackTransaction()
    {
        throw new NotImplementedException();
    }

    public virtual void RollbackTransactionAsync()
    {
        throw new NotImplementedException();
    }

    public virtual int SaveChange()
    {
        throw new NotImplementedException();
    }

    public virtual Task<int> SaveChangeAsync()
    {
        throw new NotImplementedException();
    }

    public virtual bool Update(TDTO entity)
    {
        throw new NotImplementedException();
    }

    public virtual bool Update(TDTO entity, TId id)
    {
        throw new NotImplementedException();
    }

    public virtual Task UpdateAsync(TDTO entity)
    {
        throw new NotImplementedException();
    }

    public virtual Task UpdateAsync(TDTO entity, TId id)
    {
        throw new NotImplementedException();
    }
}

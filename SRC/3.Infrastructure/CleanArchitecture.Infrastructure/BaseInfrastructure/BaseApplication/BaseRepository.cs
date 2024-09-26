using CleanArchitecture.Application.BaseApplication.Models.DTOs;
using CleanArchitecture.Application.BaseApplication.Models.Views;
using CleanArchitecture.Application.BaseApplication.Patterns;
using CleanArchitecture.Application.BaseApplication.Repositories;
using CleanArchitecture.Application.BaseApplication.UserManagement;
using CleanArchitecture.Application.Providers.MapperProvider.Abstract;
using CleanArchitecture.Domain.BasesDomain;
using CleanArchitecture.Infrastructure.BaseInfrastructure.UserManagement;
using CleanArchitecture.Infrastructure.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq.Expressions;

namespace CleanArchitecture.Infrastructure.BaseInfrastructure.BaseApplication;

public abstract class BaseRepository<TContext, TEntity, TDTO, TView, TId>
    : IBaseRepository<TEntity, TDTO, TView, TId>
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
    protected readonly ILogger Logger;
    protected readonly TContext context;
    protected readonly IMapperAdapter MapperFacad;
    public IUserWebInfoRepositories CurrentUserInfo => new UserWebInfoService();
    protected BaseRepository(
        TContext context,
        IMapperAdapter mapperFacad,
        ILogger logger)
    {
        this.context = context;
        MapperFacad = mapperFacad;
        Logger = logger;
        Logger.LogInformation("BaseRepository");
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

    public async Task<List<TModel>> ExecuteQueryDataList<TModel>(string query, params object[] parameters)
    {
        var result = await context.Database.SqlQueryRaw<TModel>(query,parameters).ToListAsync();
        return result;
    }
    public async Task<TModel> ExecuteQueryData<TModel>(string query, params object[] parameters)
    {
        var result = await context.Database.SqlQueryRaw<TModel>(query,parameters).FirstOrDefaultAsync();
        return await Task.FromResult(result);
    }

    bool IBaseRepository<TEntity, TDTO, TView, TId>.Insert(TDTO entity)
    {
        throw new NotImplementedException();
    }

    Task IBaseRepository<TEntity, TDTO, TView, TId>.InsertAsync(TDTO entity)
    {
        throw new NotImplementedException();
    }

    bool IBaseRepository<TEntity, TDTO, TView, TId>.Update(TDTO entity)
    {
        throw new NotImplementedException();
    }

    bool IBaseRepository<TEntity, TDTO, TView, TId>.Update(TDTO entity, TId id)
    {
        throw new NotImplementedException();
    }

    Task IBaseRepository<TEntity, TDTO, TView, TId>.UpdateAsync(TDTO entity)
    {
        throw new NotImplementedException();
    }

    Task IBaseRepository<TEntity, TDTO, TView, TId>.UpdateAsync(TDTO entity, TId id)
    {
        throw new NotImplementedException();
    }

    bool IBaseRepository<TEntity, TDTO, TView, TId>.Delete(TId id)
    {
        throw new NotImplementedException();
    }

    bool IBaseRepository<TEntity, TDTO, TView, TId>.DeleteGraph(TId id)
    {
        throw new NotImplementedException();
    }

    bool IBaseRepository<TEntity, TDTO, TView, TId>.Delete(TDTO entity)
    {
        throw new NotImplementedException();
    }

    bool IBaseRepository<TEntity, TDTO, TView, TId>.AddOrUpdate(TDTO entity)
    {
        throw new NotImplementedException();
    }

    Task IBaseRepository<TEntity, TDTO, TView, TId>.AddOrUpdateAsync(TDTO entity)
    {
        throw new NotImplementedException();
    }

    TView IBaseRepository<TEntity, TDTO, TView, TId>.Get(TId id)
    {
        throw new NotImplementedException();
    }

    Task<TView> IBaseRepository<TEntity, TDTO, TView, TId>.GetAsync(TId id)
    {
        throw new NotImplementedException();
    }

    TView IBaseRepository<TEntity, TDTO, TView, TId>.Get(Guid Guid)
    {
        throw new NotImplementedException();
    }

    Task<TView> IBaseRepository<TEntity, TDTO, TView, TId>.GetAsync(Guid Guid)
    {
        throw new NotImplementedException();
    }

    TView IBaseRepository<TEntity, TDTO, TView, TId>.Get()
    {
        throw new NotImplementedException();
    }

    Task<IEnumerable<TView>> IBaseRepository<TEntity, TDTO, TView, TId>.GetAsync()
    {
        throw new NotImplementedException();
    }

    TView IBaseRepository<TEntity, TDTO, TView, TId>.GetGraph(TId id)
    {
        throw new NotImplementedException();
    }

    Task<TView> IBaseRepository<TEntity, TDTO, TView, TId>.GetGraphAsync(TId id)
    {
        throw new NotImplementedException();
    }

    TView IBaseRepository<TEntity, TDTO, TView, TId>.GetGraph(Guid Guid)
    {
        throw new NotImplementedException();
    }

    Task<TView> IBaseRepository<TEntity, TDTO, TView, TId>.GetGraphAsync(Guid Guid)
    {
        throw new NotImplementedException();
    }

    bool IBaseRepository<TEntity, TDTO, TView, TId>.Exists(Expression<Func<TDTO, bool>> expression)
    {
        throw new NotImplementedException();
    }

    Task<bool> IBaseRepository<TEntity, TDTO, TView, TId>.ExistsAsync(Expression<Func<TDTO, bool>> expression)
    {
        throw new NotImplementedException();
    }

    void IUnitOfWork.BeginTransaction()
    {
        throw new NotImplementedException();
    }

    void IUnitOfWork.BeginTransactionAsync()
    {
        throw new NotImplementedException();
    }

    void IUnitOfWork.CommitTransaction()
    {
        throw new NotImplementedException();
    }

    void IUnitOfWork.CommitTransactionAsync()
    {
        throw new NotImplementedException();
    }

    void IUnitOfWork.RollbackTransaction()
    {
        throw new NotImplementedException();
    }

    void IUnitOfWork.RollbackTransactionAsync()
    {
        throw new NotImplementedException();
    }

    int IUnitOfWork.SaveChange()
    {
        throw new NotImplementedException();
    }

    Task<int> IUnitOfWork.SaveChangeAsync()
    {
        throw new NotImplementedException();
    }
}

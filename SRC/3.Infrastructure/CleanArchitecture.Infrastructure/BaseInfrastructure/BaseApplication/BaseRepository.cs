using CleanArchitecture.Application.BaseApplication.Models.DTOs;
using CleanArchitecture.Application.BaseApplication.Models.Views;
using CleanArchitecture.Application.BaseApplication.Repositories;
using CleanArchitecture.Application.BaseApplication.UserManagement;
using CleanArchitecture.Application.Providers.MapperProvider.Abstract;
using CleanArchitecture.Domain.BasesDomain;
using CleanArchitecture.Infrastructure.BaseInfrastructure.Pattern;
using CleanArchitecture.Infrastructure.BaseInfrastructure.UserManagement;
using CleanArchitecture.Infrastructure.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq.Expressions;

namespace CleanArchitecture.Infrastructure.BaseInfrastructure.BaseApplication;

public abstract class BaseRepository<TContext, TEntity, TDTO, TView, TId>
    : UnitOfWork<TContext>,IBaseRepository<TEntity, TDTO, TView, TId>
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
    protected readonly TContext Context;
    protected readonly ILogger Logger;
    protected readonly IMapperAdapter MapperFacad;

    protected BaseRepository(TContext context, ILogger logger, IMapperAdapter mapperFacad) : base(context)
    {
        Context = context;
        Logger = logger;
        MapperFacad = mapperFacad;
    }

    public IUserWebInfoRepositories CurrentUserInfo => new UserWebInfoService();
   

    public async Task<List<TModel>> ExecuteQueryDataList<TModel>(string query, params object[] parameters)
    {
        var result = await Context.Database.SqlQueryRaw<TModel>(query,parameters).ToListAsync();
        return result;
    }
    public async Task<TModel> ExecuteQueryData<TModel>(string query, params object[] parameters)
    {
        var result = await Context.Database.SqlQueryRaw<TModel>(query,parameters).FirstOrDefaultAsync();
        return await Task.FromResult(result);
    }

    public bool Insert(TDTO entity)
    {
        throw new NotImplementedException();
    }

    public Task InsertAsync(TDTO entity)
    {
        throw new NotImplementedException();
    }

    public bool Update(TDTO entity)
    {
        throw new NotImplementedException();
    }

    public bool Update(TDTO entity, TId id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(TDTO entity)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(TDTO entity, TId id)
    {
        throw new NotImplementedException();
    }

    public bool Delete(TId id)
    {
        throw new NotImplementedException();
    }

    public bool DeleteGraph(TId id)
    {
        throw new NotImplementedException();
    }

    public bool Delete(TDTO entity)
    {
        throw new NotImplementedException();
    }

    public Task<TId> AddOrUpdate(TDTO entity)
    {
        throw new NotImplementedException();
    }

    public Task<TId> AddOrUpdateAsync(TDTO entity)
    {
        throw new NotImplementedException();
    }

    public TView Get(TId id)
    {
        throw new NotImplementedException();
    }

    public Task<TView> GetAsync(TId id)
    {
        throw new NotImplementedException();
    }

    public TView Get(Guid Guid)
    {
        throw new NotImplementedException();
    }

    public Task<TView> GetAsync(Guid Guid)
    {
        throw new NotImplementedException();
    }

    public TView Get()
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<TView>> GetAsync()
    {
        throw new NotImplementedException();
    }

    public TView GetGraph(TId id)
    {
        throw new NotImplementedException();
    }

    public Task<TView> GetGraphAsync(TId id)
    {
        throw new NotImplementedException();
    }

    public TView GetGraph(Guid Guid)
    {
        throw new NotImplementedException();
    }

    public Task<TView> GetGraphAsync(Guid Guid)
    {
        throw new NotImplementedException();
    }

    public bool Exists(Expression<Func<TDTO, bool>> expression)
    {
        throw new NotImplementedException();
    }

    public Task<bool> ExistsAsync(Expression<Func<TDTO, bool>> expression)
    {
        throw new NotImplementedException();
    }

}

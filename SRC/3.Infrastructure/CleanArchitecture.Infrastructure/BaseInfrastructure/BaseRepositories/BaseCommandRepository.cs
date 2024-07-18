using CleanArchitecture.Application.BaseApplication.Patterns;
using CleanArchitecture.Application.BaseApplication.Repositories;
using CleanArchitecture.Domain.BasesDomain;
using CleanArchitecture.Domain.BasesDomain.ValueObjects.BusinessId;
using CleanArchitecture.Infrastructure.BaseInfrastructure.BaseDatabaseContext;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CleanArchitecture.Infrastructure.BaseInfrastructure.BaseRepositories;

/// <summary>
/// 
/// </summary>
/// <typeparam name="TEntity"></typeparam>
/// <typeparam name="TDbContext"></typeparam>
/// <typeparam name="TId"></typeparam>
public class BaseCommandRepository<TEntity, TDbContext, TId>
    : IBaseCommandRepository<TEntity, TId>, IUnitOfWork
    where TEntity : class, IEntity<TId>, new()
    where TDbContext : BaseCommandDatabaseContext
    where TId : struct,
                IComparable,
                IComparable<TId>,
                IConvertible,
                IEquatable<TId>,
                IFormattable

{
    protected readonly TDbContext _dbContext;

    public BaseCommandRepository(TDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    #region AddOrUpdate
    public void AddOrUpdate(TEntity entity)
    {
        if (entity.Id.Equals("0"))
            Insert(entity);
        else
            Update(entity);
    }

    public async Task AddOrUpdateAsync(TEntity entity)
    {
        if (entity.Id.Equals("0"))
            await InsertAsync(entity);
        else
            await UpdateAsync(entity);
    }
    #endregion

    #region SaveChange
    public int SaveChange()
    {
        return _dbContext.SaveChanges();
    }

    public async Task<int> SaveChangeAsync()
    {
        return await _dbContext.SaveChangesAsync();
    }
    #endregion

    #region Insert
    public void Insert(TEntity entity)
    {
        _dbContext.Set<TEntity>().Add(entity);
    }

    public async Task InsertAsync(TEntity entity)
    {
        await _dbContext.Set<TEntity>().AddAsync(entity);
    }
    #endregion

    #region Update
    public void Update(TEntity entity)
    {
        _dbContext.Set<TEntity>().Update(entity);
    }
    public async Task UpdateAsync(TEntity entity)
    {
        _dbContext.Set<TEntity>().Update(entity);
        await Task.CompletedTask;
    }

    public void Update(TEntity entity, TId id)
    {
        var result = _dbContext.Set<TEntity>().Find(id);
        result = entity;
        _dbContext.Update(result);
    }
    public async Task UpdateAsync(TEntity entity, TId id)
    {
        var result = await _dbContext.Set<TEntity>().FindAsync(id);
        result = entity;
        _dbContext.Update(result);
    }

    #endregion

    #region Delete
    public void Delete(TId id)
    {
        _dbContext.Set<TEntity>().Remove(Get(id));
    }

    public void Delete(TEntity entity)
    {
        _dbContext.Set<TEntity>().Remove(entity);
    }
    #endregion

    #region Graph
    public void DeleteGraph(TId id)
    {
        throw new NotImplementedException();
    }
    public TEntity GetGraph(TId id)
    {
        throw new NotImplementedException();
    }

    public TEntity GetGraph(BusinessId businessId)
    {
        throw new NotImplementedException();
    }

    public Task<TEntity> GetGraphAsync(TId id)
    {
        throw new NotImplementedException();
    }

    public Task<TEntity> GetGraphAsync(BusinessId businessId)
    {
        throw new NotImplementedException();
    }
    #endregion

    #region Get
    public TEntity Get(TId id)
        => _dbContext.Set<TEntity>().Find(id);

    public TEntity Get(BusinessId businessId)
        => _dbContext.Set<TEntity>().FirstOrDefault(item => item.Key.Equals(businessId));

    public async Task<TEntity> GetAsync(TId id)
        => await _dbContext.Set<TEntity>().FindAsync(id);

    public async Task<TEntity> GetAsync(BusinessId businessId)
        => await _dbContext.Set<TEntity>().FirstOrDefaultAsync(item => item.Key.Equals(businessId));
    #endregion

    #region GetList
    #endregion

    #region Exists
    public bool Exists(Expression<Func<TEntity, bool>> expression)
    {
        throw new NotImplementedException();
    }

    public Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> expression)
    {
        throw new NotImplementedException();
    }
    #endregion

    #region Transaction
    public void BeginTransaction()
    {
        _dbContext.Database.BeginTransaction();
    }
    public void BeginTransactionAsync()
    {
        _dbContext.Database.BeginTransactionAsync();
    }

    public void CommitTransactionAsync()
    {
        _dbContext.Database.CommitTransactionAsync();
    }
    public void CommitTransaction()
    {
        _dbContext.Database.CommitTransaction();
    }

    public void RollbackTransaction()
    {
        _dbContext.Database.RollbackTransaction();
    }
    public void RollbackTransactionAsync()
    {
        _dbContext.Database.RollbackTransactionAsync();
    }
    #endregion

}

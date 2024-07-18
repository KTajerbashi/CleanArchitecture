using CleanArchitecture.Application.BaseApplication.Repositories;
using CleanArchitecture.Infrastructure.BaseInfrastructure.BaseDatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infrastructure.BaseInfrastructure.BaseRepositories;

/// <summary>
/// پایه سرویس خواندن
/// </summary>
/// <typeparam name="TDbContext"></typeparam>
public class BaseQueryRepository<TDbContext, TEntity, TId> : IBaseQueryRepository<TEntity, TId>
    where TDbContext : BaseQueryDatabaseContext
    where TEntity : class, new()
{
    protected readonly TDbContext _dbContext;
    public BaseQueryRepository(TDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<TEntity> GetAsync(TId id)
    {
        return await _dbContext.Set<TEntity>().FindAsync(id);
    }

    public async Task<IEnumerable<TEntity>> GetAsync()
    {
        return await _dbContext.Set<TEntity>().ToListAsync();
    }
}

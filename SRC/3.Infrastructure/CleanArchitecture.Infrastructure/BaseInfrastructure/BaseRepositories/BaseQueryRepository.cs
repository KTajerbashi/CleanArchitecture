using CleanArchitecture.Application.BaseApplication.Repositories;
using CleanArchitecture.Infrastructure.BaseInfrastructure.DatabaseContext;

namespace CleanArchitecture.Infrastructure.BaseInfrastructure.BaseRepositories;

/// <summary>
/// پایه سرویس خواندن
/// </summary>
/// <typeparam name="TDbContext"></typeparam>
public class BaseQueryRepository<TDbContext> : IBaseQueryRepository
    where TDbContext : BaseQueryDatabaseContext
{
    protected readonly TDbContext _dbContext;
    public BaseQueryRepository(TDbContext dbContext)
    {
        _dbContext = dbContext;
    }
}

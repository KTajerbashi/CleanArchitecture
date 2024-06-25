using CleanArchitecture.Application.BaseApplication.Repositories;
using CleanArchitecture.Infrastructure.BaseInfrastructure.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

using CleanArchitecture.Application.Repositories.Security.Repository;
using CleanArchitecture.Infrastructure.BaseInfrastructure.BaseRepositories;
using CleanArchitecture.Infrastructure.DatabaseContext;

namespace CleanArchitecture.Infrastructure.Repositories.Security;

public class QueryUserRepository : BaseQueryRepository<QueryDatabaseContext>, IQueryUserRepository
{
    public QueryUserRepository(QueryDatabaseContext dbContext) : base(dbContext)
    {
    }

}

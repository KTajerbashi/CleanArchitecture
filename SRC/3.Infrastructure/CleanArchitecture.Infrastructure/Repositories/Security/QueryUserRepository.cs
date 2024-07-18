using CleanArchitecture.Application.Repositories.Security.User.Queries;
using CleanArchitecture.Domain.Security;
using CleanArchitecture.Infrastructure.BaseInfrastructure.BaseRepositories;
using CleanArchitecture.Infrastructure.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infrastructure.Repositories.Security;

public class QueryUserRepository : BaseQueryRepository<CleanArchitectureQueryDb,UserEntity,long>, IUserQueryRepository
{
    public QueryUserRepository(CleanArchitectureQueryDb dbContext) : base(dbContext)
    {
    }

}

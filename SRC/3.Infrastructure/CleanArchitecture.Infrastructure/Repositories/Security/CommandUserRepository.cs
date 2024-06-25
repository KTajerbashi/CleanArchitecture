using CleanArchitecture.Application.Repositories.Security.Repository;
using CleanArchitecture.Domain.Security;
using CleanArchitecture.Infrastructure.BaseInfrastructure.BaseRepositories;
using CleanArchitecture.Infrastructure.DatabaseContext;

namespace CleanArchitecture.Infrastructure.Repositories.Security;

public class CommandUserRepository : BaseCommandRepository<UserEntity, CommandDatabaseContext, long>, ICommandUserRepository
{
    public CommandUserRepository(CommandDatabaseContext dbContext) : base(dbContext)
    {
    }
}

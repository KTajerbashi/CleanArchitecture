using CleanArchitecture.Application.Repositories.Security.User.Command;
using CleanArchitecture.Domain.Security;
using CleanArchitecture.Infrastructure.BaseInfrastructure.BaseRepositories;
using CleanArchitecture.Infrastructure.DatabaseContext;

namespace CleanArchitecture.Infrastructure.Repositories.Security;

public class CommandUserRepository : BaseCommandRepository<UserEntity, CleanArchitectureCommandDb, long>, IUserCommandRepository
{
    public CommandUserRepository(CleanArchitectureCommandDb dbContext) : base(dbContext)
    {
    }
}

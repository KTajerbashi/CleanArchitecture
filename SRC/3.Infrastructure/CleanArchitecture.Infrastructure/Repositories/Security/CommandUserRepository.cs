using CleanArchitecture.Application.Repositories.Security.User.Repository;
using CleanArchitecture.Domain.Security;
using CleanArchitecture.Infrastructure.BaseInfrastructure.BaseApplication;
using CleanArchitecture.Infrastructure.DatabaseContext;

namespace CleanArchitecture.Infrastructure.Repositories.Security;

public class CommandUserRepository : BaseRepository<CleanArchitectureDb, UserEntity, long>, IUserRepository
{
    public CommandUserRepository(CleanArchitectureDb context) : base(context)
    {
    }
}

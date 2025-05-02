using CleanArchitecture.Core.Application.Library.UseCases.Security.User.Repositories;

namespace CleanArchitecture.Infra.SqlServer.Library.UseCases.Security.User.Repositories;

public class UserRepository : Repository<AppUserEntity, long>, IUserRepository
{
    public UserRepository(DatabaseContext context) : base(context)
    {
    }
}

public class UserLoginRepository : Repository<AppUserLoginEntity, long>, IUserLoginRepository
{
    public UserLoginRepository(DatabaseContext context) : base(context)
    {
    }
}

public class UserTokenRepository : Repository<AppUserTokenEntity, long>, IUserTokenRepository
{
    public UserTokenRepository(DatabaseContext context) : base(context)
    {
    }
}

public class UserRoleRepository : Repository<AppUserRoleEntity, long>, IUserRoleRepository
{
    public UserRoleRepository(DatabaseContext context) : base(context)
    {
    }
}

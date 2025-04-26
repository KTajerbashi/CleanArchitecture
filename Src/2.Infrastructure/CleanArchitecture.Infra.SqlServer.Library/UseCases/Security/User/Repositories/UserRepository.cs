using CleanArchitecture.Core.Application.Library.UseCases.Security.User.Repositories;

namespace CleanArchitecture.Infra.SqlServer.Library.UseCases.Security.User.Repositories;

public class UserRepository : Repository<AppUserEntity, long>, IUserRepository
{
}

public class UserLoginRepository : Repository<AppUserLoginEntity, long>, IUserLoginRepository
{
}

public class UserTokenRepository : Repository<AppUserTokenEntity, long>, IUserTokenRepository
{
}

public class UserRoleRepository : Repository<AppUserRoleEntity, long>, IUserRoleRepository
{
}

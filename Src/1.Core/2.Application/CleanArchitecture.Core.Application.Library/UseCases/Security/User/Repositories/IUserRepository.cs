using CleanArchitecture.Core.Application.Library.Common.Repository;
using CleanArchitecture.Core.Domain.Library.UseCases.Security;

namespace CleanArchitecture.Core.Application.Library.UseCases.Security.User.Repositories;

public interface IUserRepository : IRepository<AppUserEntity, long>
{
}


public interface IUserLoginRepository : IRepository<AppUserLoginEntity, long>
{
}



public interface IUserTokenRepository : IRepository<AppUserTokenEntity, long>
{
}


public interface IUserRoleRepository : IRepository<AppUserRoleEntity, long>
{
}

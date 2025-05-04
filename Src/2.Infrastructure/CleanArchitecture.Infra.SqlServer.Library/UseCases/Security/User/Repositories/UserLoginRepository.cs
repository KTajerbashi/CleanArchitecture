using CleanArchitecture.Core.Application.Library.UseCases.Security.User.Repositories;

namespace CleanArchitecture.Infra.SqlServer.Library.UseCases.Security.User.Repositories;

public class UserLoginRepository : Repository<AppUserLoginEntity, long>, IUserLoginRepository
{
    public UserLoginRepository(DatabaseContext context) : base(context)
    {
    }
}

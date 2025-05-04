using CleanArchitecture.Core.Application.Library.UseCases.Security.User.Repositories;

namespace CleanArchitecture.Infra.SqlServer.Library.UseCases.Security.User.Repositories;

public class UserTokenRepository : Repository<AppUserTokenEntity, long>, IUserTokenRepository
{
    public UserTokenRepository(DatabaseContext context) : base(context)
    {
    }
}

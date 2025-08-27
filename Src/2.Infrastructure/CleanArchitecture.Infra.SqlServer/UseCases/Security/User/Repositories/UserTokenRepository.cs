using CleanArchitecture.Core.Application.UseCases.Security.User.Repositories;
using CleanArchitecture.Core.Domain.UseCases.Security;
using CleanArchitecture.Infra.SqlServer.Common.Repository;
using CleanArchitecture.Infra.SqlServer.Data;

namespace CleanArchitecture.Infra.SqlServer.UseCases.Security.User.Repositories;

public class UserTokenRepository : Repository<AppUserTokenEntity, long>, IUserTokenRepository
{
    public UserTokenRepository(DatabaseContext context) : base(context)
    {
    }
}

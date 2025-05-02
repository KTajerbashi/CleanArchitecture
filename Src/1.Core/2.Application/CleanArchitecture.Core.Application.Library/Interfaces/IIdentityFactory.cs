using CleanArchitecture.Core.Application.Library.Providers.Scrutor;
using CleanArchitecture.Core.Domain.Library.UseCases.Security;

namespace CleanArchitecture.Core.Application.Library.Interfaces;

public interface IIdentityFactory : IScopeLifeTime
{
    string PasswordHash(AppUserEntity entity, string password);
    bool VerifyHashedPassword(AppUserEntity entity, string passwordHash, string password);
    string ConcurrencyStamp(string password);
    string SecurityStamp(string password);
}

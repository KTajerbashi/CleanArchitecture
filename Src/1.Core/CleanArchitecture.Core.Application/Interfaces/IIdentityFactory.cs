using CleanArchitecture.Core.Application.Providers.Scrutor;
using CleanArchitecture.Core.Domain.UseCases.Security;

namespace CleanArchitecture.Core.Application.Interfaces;

public interface IIdentityFactory : IScopeLifeTime
{
    string PasswordHash(AppUserEntity entity, string password);
    bool VerifyHashedPassword(AppUserEntity entity, string passwordHash, string password);
    string ConcurrencyStamp(string password);
    string SecurityStamp(string password);
}

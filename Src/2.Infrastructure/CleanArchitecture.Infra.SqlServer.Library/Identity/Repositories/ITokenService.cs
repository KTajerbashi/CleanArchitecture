using CleanArchitecture.Core.Application.Library.Providers.Scrutor;
using System.Security.Claims;

namespace CleanArchitecture.Infra.SqlServer.Library.Identity.Repositories;

public interface ITokenService : IScopeLifeTime
{
    Task<string> GenerateAccessTokenAsync(UserEntity user);
    string GenerateRefreshToken();
    ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
}


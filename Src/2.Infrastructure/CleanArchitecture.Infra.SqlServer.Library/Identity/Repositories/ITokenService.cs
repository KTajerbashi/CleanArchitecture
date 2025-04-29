using CleanArchitecture.Core.Application.Library.Providers.Scrutor;
using CleanArchitecture.Infra.SqlServer.Library.Identity.Models;
using System.Security.Claims;

namespace CleanArchitecture.Infra.SqlServer.Library.Identity.Repositories;

public interface ITokenService : IScopeLifeTime
{
    Task<AuthResponse> GenerateAccessTokenAsync(UserEntity user);
    string GenerateRefreshToken();
    ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
}


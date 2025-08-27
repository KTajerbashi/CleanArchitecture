using CleanArchitecture.Core.Application.Providers.Scrutor;
using CleanArchitecture.Infra.SqlServer.Identity.Entities;
using CleanArchitecture.Infra.SqlServer.Identity.Models;
using System.Security.Claims;

namespace CleanArchitecture.Infra.SqlServer.Identity.Repositories;

public interface ITokenService : IScopeLifeTime
{
    Task<AuthResponse> GenerateAccessTokenAsync(UserEntity user);
    string GenerateRefreshToken();
    ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
}


using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace CleanArchitecture.Infra.SqlServer.Library.Identity.Extensions;

public static class IdentityExtensions
{
    public static string GetClaimValue(this ClaimsPrincipal userClaimsPrincipal, string claimType)
    {
        return userClaimsPrincipal.Claims.FirstOrDefault((x) => x.Type == claimType)?.Value!;
    }
    public static Claim GetClaim(this ClaimsPrincipal userClaimsPrincipal, string claimType)
    {
        return userClaimsPrincipal.Claims.FirstOrDefault((x) => x.Type == claimType)!;
    }

}

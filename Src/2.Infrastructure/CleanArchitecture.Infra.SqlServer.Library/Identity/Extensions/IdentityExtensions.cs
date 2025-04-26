using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace CleanArchitecture.Infra.SqlServer.Library.Identity.Extensions;

public static class IdentityExtensions
{
    public static Result ToApplicationResult(this IdentityResult result)
    {
        return result.Succeeded
            ? Result.Success()
            : Result.Failure(result.Errors.Select(e => e.Description));
    }
    public static Result ToApplicationResult(this SignInResult? result)
    {
        return result!.Succeeded
            ? Result.Success()
            : Result.Failure(["SignIn Faild !!!"]);
    }

    public static string GetClaimValue(this ClaimsPrincipal userClaimsPrincipal, string claimType)
    {
        return userClaimsPrincipal.Claims.FirstOrDefault((x) => x.Type == claimType)?.Value!;
    }
    public static Claim GetClaim(this ClaimsPrincipal userClaimsPrincipal, string claimType)
    {
        return userClaimsPrincipal.Claims.FirstOrDefault((x) => x.Type == claimType)!;
    }

}

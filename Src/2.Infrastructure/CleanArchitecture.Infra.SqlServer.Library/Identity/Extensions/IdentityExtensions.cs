using Microsoft.AspNetCore.Identity;

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
}

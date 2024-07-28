using System.Security.Claims;

namespace CleanArchitecture.WebApi.DIContainer.ContextAccessor;

public interface IUserManagement
{
    IHttpContextAccessor HttpContextAccessor { get; }

    bool IsUserAdmin();

    IEnumerable<string> GetUserRoles();

    IEnumerable<Claim> GetUserClaims();

    string GetClaimValue(string claimType);
}

public class UserManagement : IUserManagement
{
    public IHttpContextAccessor HttpContextAccessor => new HttpContextAccessor();
   
    public bool IsUserAdmin()
    {
        var user = HttpContextAccessor.HttpContext.User;
        return user.HasClaim(ClaimTypes.Role, "Admin");
    }

    public IEnumerable<string> GetUserRoles()
    {
        var user = HttpContextAccessor.HttpContext.User;
        if (user == null)
        {
            return Enumerable.Empty<string>();
        }

        // Extract roles from claims
        return user.Claims
                   .Where(c => c.Type == ClaimTypes.Role)
                   .Select(c => c.Value);
    }
    public IEnumerable<Claim> GetUserClaims()
    {
        var user = HttpContextAccessor.HttpContext.User;
        if (user == null)
        {
            return Enumerable.Empty<Claim>();
        }

        // Retrieve all claims
        return user.Claims;
    }

    public string GetClaimValue(string claimType)
    {
        var user = HttpContextAccessor.HttpContext.User;
        if (user == null)
        {
            return null;
        }

        // Retrieve specific claim value
        return user.FindFirst(claimType)?.Value;
    }
}


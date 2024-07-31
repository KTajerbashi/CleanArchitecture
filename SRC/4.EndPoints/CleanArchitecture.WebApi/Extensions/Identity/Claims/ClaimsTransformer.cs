using CleanArchitecture.Domain.Security.Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace CleanArchitecture.WebApi.Extensions.Identity.Claims;

public class ClaimsTransformer : IClaimsTransformation
{
    private readonly UserManager<UserEntity> _userManager;

    public ClaimsTransformer(UserManager<UserEntity> userManager)
    {
        _userManager = userManager;
    }

    public async Task<ClaimsPrincipal> TransformAsync(ClaimsPrincipal principal)
    {
        var identity = (ClaimsIdentity)principal.Identity;
        var user = await _userManager.GetUserAsync(principal);

        if (user != null)
        {
            var roles = await _userManager.GetRolesAsync(user);

            foreach (var role in roles)
            {
                // Add each role as a claim
                identity.AddClaim(new Claim(ClaimTypes.Role, role));
            }
        }

        return principal;
    }
}

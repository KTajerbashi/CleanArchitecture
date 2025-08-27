using CleanArchitecture.Core.Application.Providers;
using CleanArchitecture.Infra.SqlServer.Identity.Entities;
using CleanArchitecture.Infra.SqlServer.Identity.Models;
using CleanArchitecture.Infra.SqlServer.Identity.Repositories;

namespace CleanArchitecture.Infra.SqlServer.Identity.Service;


public class JwtTokenService : ITokenService
{
    private readonly UserManager<UserEntity> _userManager;
    private readonly IdentityOption _identityOption;
    private readonly ILogger<JwtTokenService> _logger;
    private const string loginProvider = "JWT";
    private const string tokenName = "AccessToken";
    private string RefreshToken ="";
    private readonly ProviderServices _providerServices;
    public JwtTokenService(
        UserManager<UserEntity> userManager,
        IOptions<IdentityOption> options,
        ILogger<JwtTokenService> logger,
        ProviderServices providerServices)
    {
        _userManager = userManager;
        _identityOption = options.Value;
        _logger = logger;
        RefreshToken = GenerateRefreshToken();
        _providerServices = providerServices;
    }

    public async Task<AuthResponse> GenerateAccessTokenAsync(UserEntity user)
    {
        try
        {
            var claims = await GetUserClaimsAsync(user);
            var token = await GenerateJwtToken(user,claims);
            var refreshToken = GenerateRefreshToken();
            //await TrackLoginAsync();
            return new AuthResponse
            {
                Token = token,
                RefreshToken = RefreshToken,
                ExpiresIn = DateTime.UtcNow.AddMinutes(_identityOption.Jwt.ExpireMinutes),
                User = MapToUserProfileDto(user)
            };
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error generating access token for user {UserId}", user.Id);
            throw;
        }
    }

    public string GenerateRefreshToken()
    {
        var randomNumber = new byte[64];
        using var rng = RandomNumberGenerator.Create();
        rng.GetBytes(randomNumber);
        return Convert.ToBase64String(randomNumber);
    }

    public ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
    {
        var tokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true, // We want to validate expired tokens
            ValidateIssuerSigningKey = true,
            ValidIssuer = _identityOption.Jwt.Issuer,
            ValidAudience = _identityOption.Jwt.Audience,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_identityOption.Jwt.Key)),
            ClockSkew = TimeSpan.FromMinutes(1) // Added small clock skew
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out var securityToken);

        if (securityToken is not JwtSecurityToken jwtSecurityToken ||
            !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
        {
            throw new SecurityTokenException("Invalid token");
        }

        return principal;
    }

    private async Task<List<Claim>> GetUserClaimsAsync(UserEntity user)
    {

        var claims = new List<Claim>
        {
            new(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new(JwtRegisteredClaimNames.Iat, DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString(), ClaimValueTypes.Integer64),
            new(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new(ClaimTypes.Name, user.UserName),
            new("Name", user.Name),
            new("Family", user.Family),
            new("DisplayName", user.DisplayName),
            new("UserId", user.Id.ToString()),
            new("UserRoleId", user.Id.ToString()),//    TODO
            new("RoleName", user.Id.ToString()), // TODO
            new("RoleTitle", user.Id.ToString()), //TODO
            new("Username", user.UserName),
            new("Email", user.Email),
            new("SecurityStamp", user.SecurityStamp ?? string.Empty)
        };

        // Add roles as individual claims
        var userRoles = await _userManager.GetRolesAsync(user);
        foreach (var role in userRoles)
        {
            claims.Add(new(ClaimTypes.Role, role));
        }
        claims.ForEach(item =>
        {
            _providerServices.Convertor.Serialize(item.Value);
        });
        // Handle custom claims carefully
        var userClaims = await _userManager.GetClaimsAsync(user);
        userClaims.ToArray().ToList().AddRange(userClaims);
        await _userManager.RemoveClaimsAsync(user, userClaims);
        await _userManager.AddClaimsAsync(user, claims);

        return claims;
    }

    private async Task<string> GenerateJwtToken(UserEntity user, IEnumerable<Claim> claims)
    {
        // Validate claims first
        var validClaims = new List<Claim>();
        foreach (var claim in claims)
        {
            try
            {
                // Test if the value can be serialized
                var test = JsonSerializer.Serialize(claim.Value);
                validClaims.Add(claim);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Invalid claim {claim.Type} with value {claim.Value}: {ex.Message}");
                // Convert complex claims to JSON strings
                validClaims.Add(new Claim(claim.Type, JsonSerializer.Serialize(claim.Value)));
            }
        }

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_identityOption.Jwt.Key));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
        issuer: _identityOption.Jwt.Issuer,
        audience: _identityOption.Jwt.Audience,
        claims: validClaims, // Use the validated claims
        expires: DateTime.UtcNow.AddMinutes(_identityOption.Jwt.ExpireMinutes),
        signingCredentials: creds
        );
        var tokenValue = new JwtSecurityTokenHandler().WriteToken(token);
        await _userManager.SetAuthenticationTokenAsync(user, loginProvider, RefreshToken, tokenValue);
        return tokenValue;
    }

    private UserProfileDTO MapToUserProfileDto(UserEntity user)
    {
        return new UserProfileDTO
        {
            Id = user.Id,
            Username = user.UserName,
            Email = user.Email,
            PhoneNumber = user.PhoneNumber,
            Name = user.Name,
            Family = user.Family
        };
    }
}


//public class JwtTokenService : ITokenService
//{
//    private readonly IConfiguration _configuration;
//    private readonly UserManager<UserEntity> _userManager;
//    private readonly RoleManager<RoleEntity> _roleManager;
//    private readonly ILogger<JwtTokenService> _logger;
//    private readonly IdentityOption _jwtOptions;

//    public JwtTokenService(
//           IConfiguration configuration,
//           UserManager<UserEntity> userManager,
//           RoleManager<RoleEntity> roleManager,
//           ILogger<JwtTokenService> logger,
//           IOptions<IdentityOption> identityOptions) // Change parameter type
//    {
//        _configuration = configuration;
//        _userManager = userManager;
//        _roleManager = roleManager;
//        _logger = logger;
//        _jwtOptions = identityOptions.Value; // Access the JwtOption property
//    }

//    public async Task<AuthResponse> GenerateAccessTokenAsync(UserEntity user)
//    {
//        _logger.LogInformation("Generating access token for user {UserId}", user.Id);

//        try
//        {
//            var claims = await BuildUserClaimsAsync(user);
//            var token = GenerateToken(claims);
//            var refreshToken = GenerateRefreshToken();

//            return new AuthResponse
//            {
//                Token = token,
//                RefreshToken = refreshToken,
//                ExpiresIn = DateTime.UtcNow.AddMinutes(_jwtOptions.Jwt.ExpireMinutes),
//                User = MapToUserProfileDto(user)
//            };
//        }
//        catch (Exception ex)
//        {
//            _logger.LogError(ex, "Failed to generate access token for user {UserId}", user.Id);
//            throw;
//        }
//    }

//    public string GenerateRefreshToken()
//    {
//        using var rng = RandomNumberGenerator.Create();
//        var randomNumber = new byte[64];
//        rng.GetBytes(randomNumber);
//        return Convert.ToBase64String(randomNumber);
//    }

//    public ClaimsPrincipal? GetPrincipalFromExpiredToken(string token)
//    {
//        var tokenHandler = new JwtSecurityTokenHandler();

//        try
//        {
//            var principal = tokenHandler.ValidateToken(token, new TokenValidationParameters
//            {
//                ValidateIssuer = true,
//                ValidIssuer = _jwtOptions.Jwt.Issuer,
//                ValidateAudience = true,
//                ValidAudience = _jwtOptions.Jwt.Audience,
//                ValidateIssuerSigningKey = true,
//                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.Jwt.Key)),
//                ValidateLifetime = false // We want to validate expired tokens
//            }, out var validatedToken);

//            if (validatedToken is not JwtSecurityToken jwtSecurityToken ||
//                !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
//            {
//                _logger.LogWarning("Invalid JWT token or algorithm");
//                return null;
//            }

//            return principal;
//        }
//        catch (Exception ex)
//        {
//            _logger.LogError(ex, "Failed to validate expired token");
//            return null;
//        }
//    }

//    private async Task<List<Claim>> BuildUserClaimsAsync(UserEntity user)
//    {
//        var claims = new List<Claim>
//        {
//            new(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
//            new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
//            new(JwtRegisteredClaimNames.Iat, DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString(), ClaimValueTypes.Integer64),
//            new(ClaimTypes.NameIdentifier, user.Id.ToString()),
//            new(ClaimTypes.Name, user.UserName),
//            new(ClaimTypes.Email, user.Email),
//            new("SecurityStamp", user.SecurityStamp ?? string.Empty)
//        };

//        await AddUserSpecificClaims(user, claims);
//        await AddRoleClaims(user, claims);

//        return claims.DistinctBy(c => new { c.Type, c.Value }).ToList();
//    }

//    private async Task AddUserSpecificClaims(UserEntity user, List<Claim> claims)
//    {
//        // Add profile claims
//        if (!string.IsNullOrEmpty(user.Name))
//            claims.Add(new("GivenName", user.Name));

//        if (!string.IsNullOrEmpty(user.Family))
//            claims.Add(new("FamilyName", user.Family));

//        if (!string.IsNullOrEmpty(user.PhoneNumber))
//        {
//            claims.Add(new(ClaimTypes.MobilePhone, user.PhoneNumber));
//            claims.Add(new("PhoneNumberVerified", user.PhoneNumberConfirmed.ToString(), ClaimValueTypes.Boolean));
//        }

//        // Add custom claims
//        var userClaims = await _userManager.GetClaimsAsync(user);
//        claims.AddRange(userClaims);
//    }

//    private async Task AddRoleClaims(UserEntity user, List<Claim> claims)
//    {
//        var roles = await _userManager.GetRolesAsync(user);
//        foreach (var roleName in roles)
//        {
//            claims.Add(new(ClaimTypes.Role, roleName));

//            var role = await _roleManager.FindByNameAsync(roleName);
//            if (role != null)
//            {
//                var roleClaims = await _roleManager.GetClaimsAsync(role);
//                claims.AddRange(roleClaims);
//            }
//        }
//    }

//    private string GenerateToken(IEnumerable<Claim> claims)
//    {
//        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.Jwt.Key));
//        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

//        var tokenDescriptor = new JwtSecurityToken(
//            issuer: _jwtOptions.Jwt.Issuer,
//            audience: _jwtOptions.Jwt.Audience,
//            claims: claims,
//            expires: DateTime.UtcNow.AddMinutes(_jwtOptions.Jwt.ExpireMinutes),
//            signingCredentials: credentials
//        );

//        return new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
//    }

//    private static UserProfileDTO MapToUserProfileDto(UserEntity user)
//    {
//        return new UserProfileDTO
//        {
//            Id = user.Id,
//            Name = user.Name,
//            Family = user.Family,
//            Email = user.Email,
//            Username = user.UserName,
//            PhoneNumber = user.PhoneNumber,
//        };
//    }
//}




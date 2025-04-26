using CleanArchitecture.EndPoint.WebApi.Models;
using CleanArchitecture.Infra.SqlServer.Library.Identity.Parameters;
using CleanArchitecture.Infra.SqlServer.Library.Identity.Repositories;
using Microsoft.EntityFrameworkCore;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace CleanArchitecture.EndPoint.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthenticateController : BaseController
{
    private readonly IIdentityService _identityService;
    private readonly ILogger<AuthenticateController> _logger;
    private static string TokenProvider = "JWT";
    private static string TokenName = "AccessToken";
    public AuthenticateController(
        IMediator mediator,
        IIdentityService identityService,
        ILogger<AuthenticateController> logger) : base(mediator)
    {
        _identityService = identityService;
        _logger = logger;
    }

    /// <summary>
    /// Authenticates a user with username/email and password
    /// </summary>
    /// <param name="request">Login credentials</param>
    /// <returns>Authentication result with token</returns>
    [HttpPost("login")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AuthenticationResponse))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        if (!ModelState.IsValid)
        {
            _logger.LogWarning("Invalid login request model");
            return BadRequest(ModelState);
        }

        // Find user by username or email
        var user = await _identityService.UserManager.FindByNameAsync(request.Username)
            ?? await _identityService.UserManager.FindByEmailAsync(request.Username);

        if (user == null)
        {
            _logger.LogWarning("Login attempt for non-existent user: {Username}", request.Username);
            return Unauthorized(new { Message = "Invalid credentials" });
        }

        // Check if account is active
        if (!user.IsActive)
        {
            _logger.LogWarning("Login attempt for inactive user: {UserId}", user.Id);
            return Unauthorized(new { Message = "Account is inactive" });
        }

        // Verify password
        var result = await _identityService.SignInManager.CheckPasswordSignInAsync(
            user, request.Password, lockoutOnFailure: true);

        if (!result.Succeeded)
        {
            if (result.IsLockedOut)
            {
                _logger.LogWarning("User account locked out: {UserId}", user.Id);
                return Unauthorized(new { Message = "Account locked out" });
            }
            if (result.IsNotAllowed)
            {
                _logger.LogWarning("User not allowed to sign in: {UserId}", user.Id);
                return Unauthorized(new { Message = "Account not allowed to sign in" });
            }

            _logger.LogWarning("Failed login attempt for user: {UserId}", user.Id);
            return Unauthorized(new { Message = "Invalid credentials" });
        }

        // Generate claims
        var claims = await GetUserClaimsAsync(user);

        // Generate token with claims
        var token = await _identityService.GenerateJwtTokenAsync(user,claims);
        var refreshToken = _identityService.GenerateRefreshToken();

        // Store refresh token
        await StoreRefreshTokenAsync(user, refreshToken);



        // Record login activity
        await RecordLoginActivity(user);

        _logger.LogInformation("User {UserId} logged in successfully", user.Id);

        await _identityService.SignInManager.SignInAsync(user,true);
        claims = claims.Except(claims).ToList();
        return Ok(new AuthenticationResponse
        {
            AccessToken = token,
            RefreshToken = refreshToken,
            ExpiresIn = (int)TimeSpan.FromMinutes(60).TotalSeconds,
            UserId = user.Id,
            Username = user.UserName,
            Email = user.Email,
            Claims = claims.ToDictionary(c => c.Type, c => c.Value)
        });
    }

    private async Task<List<Claim>> GetUserClaimsAsync(UserEntity user)
    {
        var oldClaims = await _identityService.UserManager.GetClaimsAsync(user);
        if (oldClaims is not null)
            await _identityService.UserManager.RemoveClaimsAsync(user, oldClaims);
        var claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(JwtRegisteredClaimNames.Iat, DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString(), ClaimValueTypes.Integer64),
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Name, user.UserName),
            new Claim(ClaimTypes.Email, user.Email),
            new Claim("IsActive", user.IsActive.ToString()),
            new Claim("DisplayName", user.DisplayName ?? string.Empty)
        };

        // Add user claims from UserClaims table
        var userClaims = await _identityService.UserManager.GetClaimsAsync(user);
        claims.AddRange(userClaims);

        // Add role claims
        var userRoles = await _identityService.UserManager.GetRolesAsync(user);
        foreach (var role in userRoles)
        {
            claims.Add(new Claim(ClaimTypes.Role, role));

            // Add role claims from RoleClaims table
            var roleEntity = await _identityService.RoleManager.FindByNameAsync(role);
            if (roleEntity != null)
            {
                var roleClaims = await _identityService.RoleManager.GetClaimsAsync(roleEntity);
                claims.AddRange(roleClaims);
            }
        }
        await _identityService.UserManager.AddClaimsAsync(user,claims);
        return claims;
    }


    private async Task StoreRefreshTokenAsync(UserEntity user, string refreshToken)
    {
        if (user == null)
        {
            throw new ArgumentNullException(nameof(user));
        }

        if (string.IsNullOrWhiteSpace(refreshToken))
        {
            throw new ArgumentException("Refresh token cannot be null or empty", nameof(refreshToken));
        }

        try
        {
            // Remove any existing token first
            await _identityService.UserManager.RemoveAuthenticationTokenAsync(user, TokenProvider, TokenName);

            // Store the new token
            //var result = await _identityService.UserManager.SetAuthenticationTokenAsync(
            //user,
            //TokenProvider,
            //TokenName,
            //refreshToken);

            //if (!result.Succeeded)
            //{
            //    var errors = string.Join(", ", result.Errors.Select(e => e.Description));
            //    _logger.LogError("Failed to store refresh token for user {UserId}: {Errors}", user.Id, errors);
            //    throw new InvalidOperationException($"Could not store refresh token: {errors}");
            //}
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error storing refresh token for user {UserId}", user.Id);
            throw; // Re-throw after logging
        }
    }

    private async Task RecordLoginActivity(UserEntity user)
    {
        await _identityService.UserManager.AddLoginAsync(user, new UserLoginInfo(TokenProvider, TokenName, user.DisplayName));
    }

    /// <summary>
    /// Registers a new user account
    /// </summary>
    [HttpPost("register")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Register([FromBody] RegisterRequest request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var parameter = new UserCreateParameters(
            request.Username,
            request.Password,
            request.Email,
            request.FirstName,
            request.LastName,
            $"{request.FirstName} {request.LastName}",
            request.PhoneNumber,
            _identityService.GeneratePersonalCode);

        var user = new UserEntity(parameter);

        var result = await _identityService.UserManager.CreateAsync(user, request.Password);

        if (!result.Succeeded)
        {
            return BadRequest(new { Errors = result.Errors.Select(e => e.Description) });
        }

        // Add default role
        await _identityService.UserManager.AddToRoleAsync(user, "User");

        // Add default claims
        var claims = new List<Claim>
        {
            new Claim("RegistrationDate", DateTime.UtcNow.ToString("o")),
            new Claim("AccountType", "Standard")
        };
        await _identityService.UserManager.AddClaimsAsync(user, claims);

        _logger.LogInformation("New user registered: {UserId}", user.Id);

        return Ok(new { Message = "Registration successful", UserId = user.Id });
    }

    /// <summary>
    /// Refreshes an authentication token
    /// </summary>
    [HttpPost("refresh-token")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AuthenticationResponse))]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenRequest request)
    {
        var principal = _identityService.GetPrincipalFromExpiredToken(request.Token);
        if (principal == null)
        {
            return BadRequest("Invalid token");
        }

        var userId = principal.FindFirstValue(ClaimTypes.NameIdentifier);
        var user = await _identityService.UserManager.FindByIdAsync(userId);

        if (user == null)
        {
            return BadRequest("Invalid user");
        }

        var currentRefreshToken = await _identityService.UserManager.GetAuthenticationTokenAsync(
            user, "MyApp", "RefreshToken");

        if (currentRefreshToken != request.RefreshToken)
        {
            return BadRequest("Invalid refresh token");
        }

        // Generate new tokens
        var claims = await GetUserClaimsAsync(user);
        var newToken = await _identityService.GenerateJwtTokenAsync(user,claims);
        var newRefreshToken = _identityService.GenerateRefreshToken();

        // Store new refresh token
        await StoreRefreshTokenAsync(user, newRefreshToken);

        return Ok(new AuthenticationResponse
        {
            AccessToken = newToken,
            RefreshToken = newRefreshToken,
            ExpiresIn = (int)TimeSpan.FromMinutes(60).TotalSeconds,
            UserId = user.Id,
            Username = user.UserName,
            Email = user.Email,
            Claims = claims.ToDictionary(c => c.Type, c => c.Value)
        });
    }

    /// <summary>
    /// Signs out the current user
    /// </summary>
    [HttpGet("logout")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> Logout()
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (string.IsNullOrEmpty(userId))
        {
            return Unauthorized();
        }

        // Remove refresh token
        var user = await _identityService.UserManager.FindByIdAsync(userId);
        if (user != null)
        {
            await _identityService.UserManager.RemoveAuthenticationTokenAsync(
                user, "MyApp", "RefreshToken");
        }

        var claims =  await _identityService.UserManager.GetClaimsAsync(user);
        if (claims != null)
            await _identityService.UserManager.RemoveClaimsAsync(user, claims);

        await _identityService.SignInManager.SignOutAsync();
        _logger.LogInformation("User {UserId} logged out", userId);

        return Ok(new { Message = "Logout successful" });
    }

    /// <summary>
    /// Gets the current user's claims
    /// </summary>
    [HttpGet("claims")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult GetClaims()
    {
        var claims = User.Claims.Select(c => new { c.Type, c.Value });
        return Ok(claims);
    }

    /// <summary>
    /// Checks if the current user is authenticated
    /// </summary>
    [HttpGet("is-authenticated")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult IsAuthenticated()
    {
        return Ok(new
        {
            IsAuthenticated = User.Identity?.IsAuthenticated ?? false,
            Username = User.Identity?.Name,
            UserId = User.FindFirstValue(ClaimTypes.NameIdentifier)
        });
    }
}


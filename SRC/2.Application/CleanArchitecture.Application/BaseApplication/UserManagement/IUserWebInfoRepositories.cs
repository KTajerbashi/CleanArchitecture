using CleanArchitecture.Application.Repositories.Security.User.Model.DTOs;

namespace CleanArchitecture.Application.BaseApplication.UserManagement;

/// <summary>
/// انتزاع دریافت کلاینت جاری درخواست
/// </summary>
public interface IUserWebInfoRepositories
{
    string GetToken();
    string GetUserAgent();
    string GetUserIp();
    string UserId();
    string GetFirstName();
    string GetLastName();
    string GetUsername();
    string? GetClaim(string claimType);
    bool IsCurrentUser(string userId);
    string UserIdOrDefault();
    string UserIdOrDefault(string defaultValue);
    Task<AuthenticateResponse?> AuthenticateAsync(AuthenticateRequest model);
    AuthenticateResponse Authenticate(AuthenticateRequest model);
}

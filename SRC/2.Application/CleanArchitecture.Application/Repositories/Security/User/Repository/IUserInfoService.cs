namespace CleanArchitecture.Application.Repositories.Security.User.Repository;

/// <summary>
/// انتزاع دریافت کلاینت جاری درخواست
/// </summary>
public interface IUserInfoService
{
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
}

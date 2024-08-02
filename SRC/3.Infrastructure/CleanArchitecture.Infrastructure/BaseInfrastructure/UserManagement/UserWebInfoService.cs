using CleanArchitecture.Application.BaseApplication.UserManagement;
using CleanArchitecture.Application.Repositories.Security.User.Model.DTOs;

namespace CleanArchitecture.Infrastructure.BaseInfrastructure.UserManagement;

public sealed class UserWebInfoService : IUserWebInfoRepositories
{
    public AuthenticateResponse Authenticate(AuthenticateRequest model)
    {
        return new AuthenticateResponse(new UserDTO(),"");
    }

    public Task<AuthenticateResponse?> AuthenticateAsync(AuthenticateRequest model)
    {
        return Task.FromResult(Authenticate(model));
    }

    public string? GetClaim(string claimType)
    {
        return "";
    }

    public string GetFirstName()
    {
        return "";
    }

    public string GetLastName()
    {
        return "";
    }

    public string GetToken()
    {
        return "";
    }

    public string GetUserAgent()
    {
        return "";
    }

    public string GetUserIp()
    {
        return "";
    }

    public string GetUsername()
    {
        return "";
    }

    public bool IsCurrentUser(string userId)
    {
        return false;
    }

    public string UserId()
    {
        return "1";
    }

    public string UserIdOrDefault()
    {
        return "1";
    }

    public string UserIdOrDefault(string defaultValue)
    {
        return "1";
    }
}

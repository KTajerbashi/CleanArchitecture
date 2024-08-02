using CleanArchitecture.Application.BaseApplication.UserManagement;
using CleanArchitecture.Application.Repositories.Security.User.Model.DTOs;

namespace CleanArchitecture.Infrastructure.BaseInfrastructure.UserManagement;

public sealed class UserWebInfoService : IUserWebInfoRepositories
{
    public AuthenticateResponse Authenticate(AuthenticateRequest model)
    {
        throw new NotImplementedException();
    }

    public Task<AuthenticateResponse?> AuthenticateAsync(AuthenticateRequest model)
    {
        throw new NotImplementedException();
    }

    public string? GetClaim(string claimType)
    {
        throw new NotImplementedException();
    }

    public string GetFirstName()
    {
        throw new NotImplementedException();
    }

    public string GetLastName()
    {
        throw new NotImplementedException();
    }

    public string GetToken()
    {
        throw new NotImplementedException();
    }

    public string GetUserAgent()
    {
        throw new NotImplementedException();
    }

    public string GetUserIp()
    {
        throw new NotImplementedException();
    }

    public string GetUsername()
    {
        throw new NotImplementedException();
    }

    public bool IsCurrentUser(string userId)
    {
        throw new NotImplementedException();
    }

    public string UserId()
    {
        throw new NotImplementedException();
    }

    public string UserIdOrDefault()
    {
        throw new NotImplementedException();
    }

    public string UserIdOrDefault(string defaultValue)
    {
        throw new NotImplementedException();
    }
}

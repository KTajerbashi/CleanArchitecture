using CleanArchitecture.Application.BaseApplication.UserManagement;
using CleanArchitecture.Application.Repositories.Security.User.Model.DTOs;

namespace CleanArchitecture.WebApi.UserManagement.Repositories;

public class FakeUserInfoService : IUserWebInfoRepositories
{
    private readonly string _defaultUserId;

    public FakeUserInfoService() : this("1")
    {

    }
    public FakeUserInfoService(string defaultUserId)
    {
        _defaultUserId = defaultUserId;
    }

    public AuthenticateResponse Authenticate(AuthenticateRequest model)
    {
        var result = new AuthenticateResponse(new UserDTO
        {
            Id = 0,
            FirstName = GetFirstName(),
            LastName = GetLastName(),
            UserName = GetUsername(),
        }, GetToken());
        return result;
    }
    public async Task<AuthenticateResponse?> AuthenticateAsync(AuthenticateRequest model)
    {
        return await Task.FromResult(Authenticate(model));
    }

    public string? GetClaim(string claimType)
    {
        return claimType;
    }

    public string GetFirstName()
    {
        return "FirstName";
    }

    public string GetLastName()
    {
        return "LastName";
    }

    public string GetToken()
    {
        return "FakeToken";
    }

    public string GetUserAgent()
    {
        return "1";
    }

    public string GetUserIp()
    {
        return "0.0.0.0";
    }

    public string GetUsername()
    {
        return "Username";
    }

    public bool HasAccess(string access)
    {
        return true;
    }

    public bool IsCurrentUser(string userId)
    {
        return true;
    }

    public string UserId()
    {
        return "1";
    }

    public string UserIdOrDefault() => _defaultUserId;

    public string UserIdOrDefault(string defaultValue) => defaultValue;


}

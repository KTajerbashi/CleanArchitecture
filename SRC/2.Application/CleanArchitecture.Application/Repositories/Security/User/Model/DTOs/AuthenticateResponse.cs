using System.ComponentModel;

namespace CleanArchitecture.Application.Repositories.Security.User.Model.DTOs;

public class AuthenticateResponse
{
    public long Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Username { get; set; }
    public string Token { get; set; }


    public AuthenticateResponse(UserDTO user, string token)
    {
        Id = user.Id;
        FirstName = user.FirstName;
        LastName = user.LastName;
        Username = user.UserName;
        Token = token;
    }
}

namespace CleanArchitecture.Application.Repositories.Security.User.Model.DTOs;

public class AuthenticateRequest
{
    public required string Username { get; set; }

    public required string Password { get; set; }
    public required bool IsRemember { get; set; }
}
namespace CleanArchitecture.Application.Repositories.Identity.Models.Responses;

public class ServiceResponse
{
    public record class GeneralResponse(bool Flage, string Message);
    public record class LoginResponse(bool Flage, string Token, string Message);
    public record class LoginResponseWithAllRoles(bool Flage, string Token, string Message);

}
public record UserSession(long? Id, string? Name, string? Email, string? Role);
public record UserSessionWithRoles(long? Id, string? Name, string? Email, List<string> Roles);


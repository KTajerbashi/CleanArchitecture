namespace CleanArchitecture.Infra.SqlServer.Library.Identity.Parameters;

public record UserCreateParameters(
    string Username,
    string Password,
    string Email,
    string Name,
    string Family,
    string DisplayName,
    string PhoneNumber,
    string PersonalCode
    );

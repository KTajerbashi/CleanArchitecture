namespace CleanArchitecture.Core.Domain.UseCases.Security.Parameters;

public record AppUserCreateParameters(
    string Name,
    string Family,
    string PersonalCode,
    string UserName,
    string Email,
    string PhoneNumber
    );

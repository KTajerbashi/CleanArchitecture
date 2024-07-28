using CleanArchitecture.Domain.Security.Enums;

namespace CleanArchitecture.WebApi.Models;

public class RegisterModel
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public GenderTypeEnum? Gender { get; set; }
    public string NationalCode { get; set; }
    public string AvatarFile { get; set; }
    public string UserName { get; set; }
    public string SignFile { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
}

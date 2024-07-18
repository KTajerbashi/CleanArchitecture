using CleanArchitecture.Application.BaseApplication.Models.DTOs;
using CleanArchitecture.Domain.Security.Enums;

namespace CleanArchitecture.Application.Repositories.Security.User.Model;

public class UserDTO : ModelDTO
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public GenderTypeEnum? Gender { get; set; }
    public string NationalCode { get; set; }
    public string AvatarFile { get; set; }
    public string SignFile { get; set; }

}

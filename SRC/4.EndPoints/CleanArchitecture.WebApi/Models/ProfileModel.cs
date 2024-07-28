using CleanArchitecture.Domain.Security.Enums;
using Extensions.Library.EnumExtensions;

namespace CleanArchitecture.WebApi.Models;

public class ProfileModel
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string UserName { get; set; }
    public string DisplayName
    {
        get
        {
            var displayName = $"{FirstName} {LastName} ({UserName})";
            return string.IsNullOrWhiteSpace(displayName) ? UserName : displayName;
        }
    }
    public GenderTypeEnum? Gender { get; set; }
    public string GenderTitle { get => EnumExtensions.GetDescription(Gender); }
    public string NationalCode { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string AvatarFile { get; set; }
}

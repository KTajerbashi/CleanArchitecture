using CleanArchitecture.Core.Application.Common.Models.Requests;

namespace CleanArchitecture.Core.Application.UseCases.Security.User.Handlers.AppUser.Create;

public class UserCreateRequest : RequestModel<UserCreateResponse>
{
    public string Name { get; set; }
    public string RoleName { get; set; }
    public string Family { get; set; }
    public string PersonalCode { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string Password { get; set; }
}

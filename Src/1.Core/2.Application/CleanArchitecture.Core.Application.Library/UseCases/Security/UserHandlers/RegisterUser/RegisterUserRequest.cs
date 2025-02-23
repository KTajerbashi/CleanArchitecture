using CleanArchitecture.Core.Application.Library.Common.Models.Requests;

namespace CleanArchitecture.Core.Application.Library.UseCases.Security.UserHandlers.RegisterUser;

public class RegisterUserRequest : RequestModel<RegisterUserResponse>
{
    public string Name { get; set; }
    public string Family { get; set; }
    public string DisplayName { get; set; }
    public string PersonalCode { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
}

namespace CleanArchitecture.Core.Application.UseCases.Security.User.Handlers.AppUser.GetAll;

public class UserGetAllRequest : RequestModel<List<UserGetAllResponse>>
{
    public string Email { get; set; }
    // Add other request properties here
}

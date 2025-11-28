namespace CleanArchitecture.Core.Application.UseCases.Security.User.Handlers.AppUser.GetAll;

public class UserGetAllResponse : BaseDTO
{
    public string Name { get; set; }
    public string Family { get; set; }
    public string Username { get; set; }
    public string DisplayName { get; set; }
    public string Email { get; set; }
}

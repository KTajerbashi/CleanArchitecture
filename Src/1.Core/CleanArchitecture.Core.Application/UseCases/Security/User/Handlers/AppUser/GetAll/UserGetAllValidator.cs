namespace CleanArchitecture.Core.Application.UseCases.Security.User.Handlers.AppUser.GetAll;

public class UserGetAllValidator : AbstractValidator<UserGetAllRequest>
{
    public UserGetAllValidator()
    {
        RuleFor(item => item.Email).EmailAddress().WithMessage("Email Is Not Correct Format ...");
        // Add other validation rules as needed
    }
}
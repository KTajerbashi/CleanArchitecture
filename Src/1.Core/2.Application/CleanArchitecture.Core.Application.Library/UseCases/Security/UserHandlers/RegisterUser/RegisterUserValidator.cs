using FluentValidation;

namespace CleanArchitecture.Core.Application.Library.UseCases.Security.UserHandlers.RegisterUser;

public class RegisterUserValidator : AbstractValidator<RegisterUserRequest> 
{
    public RegisterUserValidator()
    {
        RuleFor(item => item.Email).EmailAddress().WithMessage("Email Is Not Correct Format ...");
    }
}

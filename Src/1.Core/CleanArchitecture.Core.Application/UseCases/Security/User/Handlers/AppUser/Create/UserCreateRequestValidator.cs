namespace CleanArchitecture.Core.Application.UseCases.Security.User.Handlers.AppUser.Create;

// Validator for UserCreateRequest
public class UserCreateRequestValidator : AbstractValidator<UserCreateRequest>
{
    public UserCreateRequestValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name is required")
            .MaximumLength(100).WithMessage("Name must not exceed 100 characters");

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email is required")
            .EmailAddress().WithMessage("A valid email is required");

        //RuleFor(x => x.Age)
        //    .GreaterThanOrEqualTo(18).WithMessage("User must be at least 18 years old");
    }
}

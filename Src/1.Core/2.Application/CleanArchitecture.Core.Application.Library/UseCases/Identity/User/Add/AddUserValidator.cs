using FluentValidation;

namespace CleanArchitecture.Core.Application.Library.UseCases.Identity.User.Add;
public class AddUserValidator : AbstractValidator<AddUserRequest>
{
    public AddUserValidator()
    {
    }
}

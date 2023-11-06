using Application.Library.DatabaseServices;
using Domain.Library.Entities.SEC;
using FluentValidation;

namespace Application.Library.Validations.SEC
{
    public class UserValidations : AbstractValidator<User>
    {
        private readonly IDatabaseRepository _context;
        public UserValidations(IDatabaseRepository context)
        {
            _context = context;

            RuleFor(u => u.Username.Length == 5);
        }
    }
}

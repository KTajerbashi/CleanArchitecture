using Application.Library.Service;
using FluentValidation;

namespace Application.Library.Validators
{
    public class UserValidation : AbstractValidator<RequestRegisterUserDto>
    {
        public UserValidation() 
        {
        }
    }
}

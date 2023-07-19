using Application.Library.Interfaces;
using Application.Library.Service;
using FluentValidation;

namespace Application.Library.Validators
{
    public class UserValidation : AbstractValidator<RequestRegisterUserDto>
    {
        private readonly IDatabaseContext _context;

        public UserValidation(IDatabaseContext context)
        {
            _context = context;

            RuleFor(u => u.Name)
                .NotEmpty().WithMessage("نام خالی است")
                .NotNull().WithMessage("نام خالی است")
                ;
            RuleFor(u => u.Family)
                .NotEmpty().WithMessage("فامیلی خالی است")
                .NotNull().WithMessage("فامیلی خالی است")
                ;
            RuleFor(u => u.Phone)
                .NotEmpty().WithMessage("تلفن خالی است")
                .NotNull().WithMessage("تلفن خالی است")
                ;
            RuleFor(u => u.Email)
                .NotEmpty().WithMessage("ایمیل خالی است")
                .NotNull().WithMessage("ایمیل خالی است")
                ;
            RuleFor(u => u.Username)
                .NotEmpty().WithMessage("نام کاربری خالی است")
                .NotNull().WithMessage("نام کاربری خالی است")
                ;
            RuleFor(u => u.Password)
                .NotEmpty().WithMessage("رمز کاربری خالی است")
                .NotNull().WithMessage("رمز کاربری خالی است")
                ;
            RuleFor(u => u.RePasword)
                .NotEmpty().WithMessage("تکرار رمز خالی است")
                .NotNull().WithMessage("تکرار رمز خالی است")
                .Equal(x => x.Password)
                ;
        }
    }
}

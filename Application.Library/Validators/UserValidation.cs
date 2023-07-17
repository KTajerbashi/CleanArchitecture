using Application.Library.Service;
using FluentValidation;

namespace Application.Library.Validators
{
    public class UserValidation : AbstractValidator<RequestRegisterUserDto>
    {
        public UserValidation() 
        {
            RuleFor(x => x.Email)
                .NotNull().WithMessage("ایمیل خالی است")
                .MinimumLength(10).WithMessage("تعداد حروف ایمیل کمتر از حد مجاز است")
                .MaximumLength(50).WithMessage("تعداد حروف ایمیل بیشتر از حد مجاز است")
                .WithMessage("ایمیل معتبر نمی باشد");
            RuleFor(x => x.Name)
                .NotNull().WithMessage("نام خالی است")
                .MinimumLength(5).WithMessage("تعداد حروف ایمیل کمتر از حد مجاز است")
                .MaximumLength(50).WithMessage("تعداد حروف ایمیل بیشتر از حد مجاز است")
                .WithMessage("ایمیل معتبر نمی باشد");
        }
    }
}

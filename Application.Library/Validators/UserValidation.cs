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
                .EmailAddress().WithMessage("ایمیل درست نیست")
                .MinimumLength(10).WithMessage("تعداد حروف ایمیل کمتر از حد مجاز است")
                .MaximumLength(50).WithMessage("تعداد حروف ایمیل بیشتر از حد مجاز است")
                .WithMessage("ایمیل معتبر نمی باشد");

            RuleFor(x => x.Name)
                .NotNull().WithMessage("نام خالی است")
                .MinimumLength(5).WithMessage("تعداد حروف ایمیل کمتر از حد مجاز است")
                .MaximumLength(50).WithMessage("تعداد حروف ایمیل بیشتر از حد مجاز است")
                .WithMessage("ایمیل معتبر نمی باشد");
            
            RuleFor(x => x.Age)
                .GreaterThanOrEqualTo(18).WithMessage("سن باید حداقل 18 باشد")
                .LessThanOrEqualTo(40).WithMessage("سن حداکثر باید 40 باشد");

            RuleForEach(x => x.Address)
                .NotNull().WithMessage("")
                .NotEmpty().WithMessage("")
                .Length(30).WithMessage("")
                ;

            RuleSet(CRUD.Add.ToString(), () =>
            {
                RuleFor(x => x.Phone)
                .Matches(@"^*(?:0|98|\+98|\+980|0098|098|00980)?(9\d{9})$")
                .When(o => o != null)
                .WithMessage("شماره تلفن درست نیست");
            });


            //  When
            When(o => !string.IsNullOrEmpty(o.Phone), () =>
            {
                RuleFor(x => x.Phone).NotEmpty().Matches(@"^0(9\d{9})$");
                RuleFor(x => x.Email).Null();
            }).Otherwise(() =>
            {
                RuleFor(o => o.Email).NotEmpty().EmailAddress();
                RuleFor(x => x.Phone).Null();
            });

            //  Cascade
            //  در صورتی که یکی از شروط فیلد بود شروط بعدی رو چک نکند
            CascadeMode = CascadeMode.Stop; //  این برای همه شرط های موجود در کلاس اعمال میشود

            RuleFor(x => x.Email)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .EmailAddress()
                ;
        }
    }
}

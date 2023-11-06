using Application.Library.Validations.SEC;
using Domain.Library.Entities.SEC;
using FluentValidation;

namespace WEB_API.Services.ServiceInjection
{
    public abstract class ScopedServices
    {
        public ScopedServices(IServiceCollection services) {

            //  Fluent Validation
            services.AddScoped<IValidator<User>, UserValidations>();
        }
    }
}

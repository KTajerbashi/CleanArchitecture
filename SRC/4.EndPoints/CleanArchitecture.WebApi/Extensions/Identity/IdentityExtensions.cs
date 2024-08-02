using CleanArchitecture.WebApi.Extensions.Identity.Extensions;

namespace CleanArchitecture.WebApi.Extensions.Identity;

public static class IdentityExtensions
{
    public static IServiceCollection AddIdentityServiceConfiguration(this IServiceCollection services, IConfiguration configuration)
    =>
        services
            .AddAuthorizationService(configuration)
            //.AddJwtService(configuration)
                ;
}

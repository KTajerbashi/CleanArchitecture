using CleanArchitecture.Infra.SqlServer.Identity.Handlers;
using Microsoft.AspNetCore.Authorization;

namespace CleanArchitecture.Infra.SqlServer.Identity;

public static class DependencyInjections
{
    public static IServiceCollection AddIdentityConfigurations(this IServiceCollection services)
    {

        services.AddSingleton<IAuthorizationHandler, MinimumAgeHandler>();
        return services;
    }
}
using CleanArchitecture.WebApi.UserManagement.Repositories;
using CleanArchitecture.WebApi.UserManagement.Services;

namespace CleanArchitecture.WebApi.UserManagement.DependencyInjection;

public static class UserManagementExtension
{
    public static IServiceCollection AddUserManagement(this IServiceCollection services)
    {
        services.AddTransient<IIdentityService, IdentityService>();
        return services;
    }
}

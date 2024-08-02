using CleanArchitecture.Application.Repositories.Security.User.Repository;
using CleanArchitecture.WebApi.UserManagement.Repositories;
using CleanArchitecture.WebApi.UserManagement.Services;

namespace CleanArchitecture.WebApi.UserManagement.DependencyInjection;

public static class UserManagementExtension
{
    public static IServiceCollection AddUserManagement(this IServiceCollection services, bool userFake)
    {
        services.AddTransient<IIdentityService, IdentityService>();
        if (userFake)
            services.AddSingleton<IUserInfoService, FakeUserInfoService>();
        else
            services.AddSingleton<IUserInfoService, WebUserInfoService>();

        return services;
    }
}

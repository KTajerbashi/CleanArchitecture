using CleanArchitecture.Application.Repositories.Security.User.Repository;
using CleanArchitecture.WebApi.Extensions.Settings;
using CleanArchitecture.WebApi.UserManagement.Options;
using CleanArchitecture.WebApi.UserManagement.Repositories;
using CleanArchitecture.WebApi.UserManagement.Services;

namespace CleanArchitecture.WebApi.UserManagement.DependencyInjection;

public static class UserManagementExtension
{
    public static IServiceCollection AddUserManagement(this IServiceCollection services,IConfiguration configuration, bool userFake)
    {
        services.AddScoped<IIdentityService, IdentityService>();
        if (userFake)
            services.AddScoped<IUserInfoService, FakeUserInfoService>();
        else
            services.AddScoped<IUserInfoService, WebUserInfoService>();

        services.Configure<AppSettings>(configuration.GetSection("AppSettings"));
        services.AddScoped<UserManagementOptions>();
        services.AddScoped<AppSettings>();
        return services;
    }
}

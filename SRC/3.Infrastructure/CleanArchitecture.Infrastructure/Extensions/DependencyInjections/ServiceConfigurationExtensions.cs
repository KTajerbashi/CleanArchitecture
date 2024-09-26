using CleanArchitecture.Infrastructure.DatabaseContext;
using CleanArchitecture.Infrastructure.DatabaseContext.Configurations.Interceptors;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.Infrastructure.Extensions.DependencyInjections;

public static class ServiceConfigurationExtensions
{
    public static IServiceCollection AddDataAccess(this IServiceCollection services, IConfiguration configuration)
    {
        return services
            .AddCommandDatabase(configuration)
            .AddRepositories()
            ;
    }
    private static IServiceCollection AddCommandDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<CleanArchitectureDb>(config =>
        {
            config
            .UseSqlServer(configuration.GetConnectionString("DefaultConnection"))
            .AddInterceptors(new AddAuditDataInterceptor())
            //.EnableSensitiveDataLogging()
            ;
        });
        return services;
    }
    private static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        //services.AddScoped<IUserWebInfoRepositories, UserWebInfoService>();
        //services.AddScoped<IIdentityService, IdentityService>();
        //services.AddScoped<IUserRepository, UserRepository>();
        return services;
    }


}

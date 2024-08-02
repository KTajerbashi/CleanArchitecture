using CleanArchitecture.Application.Repositories.Security.User.Repository;
using CleanArchitecture.Infrastructure.Configurations.Interceptors;
using CleanArchitecture.Infrastructure.DatabaseContext;
using CleanArchitecture.Infrastructure.Repositories.Security.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.Infrastructure.DependencyInjections;

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
        services.AddScoped<IUserRepository, UserRepository>();
        return services;
    }


}

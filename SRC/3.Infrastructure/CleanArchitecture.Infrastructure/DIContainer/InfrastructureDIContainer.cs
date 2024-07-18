using CleanArchitecture.Application.Repositories.Security.User.Command;
using CleanArchitecture.Application.Repositories.Security.User.Queries;
using CleanArchitecture.Infrastructure.DatabaseContext;
using CleanArchitecture.Infrastructure.Repositories.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.Infrastructure.DIContainer;

public static class InfrastructureDIContainer
{
    public static IServiceCollection AddDataAccess(this IServiceCollection services, IConfiguration configuration)
    {
        return services
            .AddRepositories()
            .AddCommandDatabase(configuration)
            .AddQueryDatabase(configuration)
            ;
    }
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IUserCommandRepository, CommandUserRepository>();
        services.AddScoped<IUserQueryRepository, QueryUserRepository>();
        return services;
    }
    public static IServiceCollection AddCommandDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<CleanArchitectureCommandDb>(config =>
        {
            config.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        });
        return services;
    }
    public static IServiceCollection AddQueryDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<CleanArchitectureQueryDb>(config =>
        {
            config.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        });
        return services;
    }
}

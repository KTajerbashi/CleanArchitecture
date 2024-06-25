using CleanArchitecture.Application.Repositories.Security.Repository;
using CleanArchitecture.Infrastructure.BaseInfrastructure.DatabaseContext;
using CleanArchitecture.Infrastructure.DatabaseContext;
using CleanArchitecture.Infrastructure.Repositories.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.Infrastructure.DIContainer;

public static class InfrastructureDIContainer
{
    public static IServiceCollection AddDataAccess(this IServiceCollection services,IConfiguration configuration)
    {
        return services
            .AddRepositories()
            .AddCommandDatabase(configuration)
            .AddQueryDatabase(configuration)
            ;
    }
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<ICommandUserRepository, CommandUserRepository>();
        services.AddScoped<IQueryUserRepository, QueryUserRepository>();
        return services;
    }
    public static IServiceCollection AddCommandDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<CommandDatabaseContext>(config =>
        {
            config.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        });
        return services;
    }
    public static IServiceCollection AddQueryDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<QueryDatabaseContext>(config =>
        {
            config.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        });
        return services;
    }
}

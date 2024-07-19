﻿using CleanArchitecture.Application.Repositories.Security.User.Repository;
using CleanArchitecture.Infrastructure.DatabaseContext;
using CleanArchitecture.Infrastructure.Repositories.Security.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.Infrastructure.DIContainer;

public static class InfrastructureDIContainer
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
            config.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        });
        return services;
    }
    private static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();
        return services;
    }


}

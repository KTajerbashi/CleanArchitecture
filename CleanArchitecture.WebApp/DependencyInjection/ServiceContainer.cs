using CleanArchitecture.Domain.Library.Entities.Security;
using CleanArchitecture.Persistence.Library.DataContext;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace CleanArchitecture.WebApp.DependencyInjection
{
    public static class ServiceContainer
    {
        public static IServiceCollection AddDatabaseContext(this IServiceCollection services, string? cs)
        {
            services.AddDbContext<DBContextApplication>(options =>
            {
                options.UseSqlServer(cs);
            });
            return services;
        }
        public static IServiceCollection AddIdentity(this IServiceCollection services)
        {
            services.AddIdentity<UserEntity, RoleEntity>(options =>
            {
            }).AddEntityFrameworkStores<DBContextApplication>();

            return services;
        }
        public static IServiceCollection AddClaims(this IServiceCollection services)
        {

            return services;
        }
        public static IServiceCollection AddPolicy(this IServiceCollection services)
        {

            return services;
        }
    }
}

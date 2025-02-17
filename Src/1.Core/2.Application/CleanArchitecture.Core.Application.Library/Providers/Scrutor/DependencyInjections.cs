using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.Core.Application.Library.Providers.Scrutor;

public static class DependencyInjections
{
    public static IServiceCollection AddScrutor(this IServiceCollection services,IConfiguration configuration,string section)
    {
        return services;
    }
}
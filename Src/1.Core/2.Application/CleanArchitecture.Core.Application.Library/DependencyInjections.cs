using CleanArchitecture.Core.Application.Library.Providers;
using CleanArchitecture.Core.Application.Library.Providers.ObjectMapper;
using CleanArchitecture.Core.Application.Library.Providers.Serializer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.Core.Application.Library;

public static class DependencyInjections
{
    public static IServiceCollection AddApplicationLibrary(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAutoMapperProfiles(configuration);

        services.AddEPPlusExcelSerializer();

        services.AddMicrosoftSerializer();

        services.AddScoped<ProviderServices>();

        return services;
    }
}

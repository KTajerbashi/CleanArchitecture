using CleanArchitecture.Core.Application.Utilities.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.Core.Application.Providers.ObjectMapper;

public static class DependencyInjection
{
    public static IServiceCollection AddAutoMapperProfiles(this IServiceCollection services, IConfiguration configuration, string sectionName)
        => services.AddAutoMapperProfiles(configuration.GetSection(sectionName));

    public static IServiceCollection AddAutoMapperProfiles(this IServiceCollection services, IConfiguration configuration)
    {
        var option = configuration.Get<ObjectMapperOption>();

        var assembliesLibrary = option?.Assemblies.Split(",");
        foreach (var item in assembliesLibrary!)
        {
            var assemblies = item.GetAssemblies().ToArray();
            services.AddAutoMapper(opt =>
            {
                opt.AddMaps(assemblies);
            });
        }

        services.AddSingleton<IObjectMapper, ObjectMapperService>();
        return services;
    }

    public static IServiceCollection AddAutoMapperProfiles(this IServiceCollection services, Action<ObjectMapperOption> setupAction)
    {
        var option = new ObjectMapperOption();
        setupAction.Invoke(option);

        var assemblies = option.Assemblies.GetAssemblies().ToArray();

        services.AddAutoMapper(opt =>
        {
            opt.AddMaps(assemblies);
        });
        services.AddSingleton<IObjectMapper, ObjectMapperService>();

        return services;
    }
}



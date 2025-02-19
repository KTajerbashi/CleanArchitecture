using CleanArchitecture.Core.Application.Library.Utilities.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.Core.Application.Library.Providers.ObjectMapper;

public static class DependencyInjection
{
    public static IServiceCollection AddAutoMapperProfiles(this IServiceCollection services,IConfiguration configuration,string sectionName)
        => services.AddAutoMapperProfiles(configuration.GetSection(sectionName));

    public static IServiceCollection AddAutoMapperProfiles(this IServiceCollection services, IConfiguration configuration)
    {
        var option = configuration.Get<ObjectMapperOption>();

        var assembliesLibrary = option.Assemblies.Split(",");
        foreach (var item in assembliesLibrary)
        {
            var assemblies = AssemblyExtensions.GetAssemblies(item);
            services.AddAutoMapper(assemblies);

            services.AddSingleton<IObjectMapper, ObjectMapperService>();
        }

        return services;
    }
    public static IServiceCollection AddAutoMapperProfiles(this IServiceCollection services, Action<ObjectMapperOption> setupAction)
    {
        var option = new ObjectMapperOption();
        setupAction.Invoke(option);

        var assemblies = AssemblyExtensions.GetAssemblies(option.Assemblies);

        return services.AddAutoMapper(assemblies).AddSingleton<IObjectMapper, ObjectMapperService>();
    }
}

using CleanArchitecture.WebApi.Middlewares.ExceptionHandler;
using CleanArchitecture.WebApi.DIContainer.DependencyInjections;
using ObjectMapper.Implementations.Extensions.DependencyInjection;
using Serilog;
using CleanArchitecture.WebApi.DIContainer.IdentityExtensions;
using CleanArchitecture.WebApi.DIContainer.SwaggerExtensions;
using CleanArchitecture.WebApi.DIContainer.ContextAccessor;

namespace CleanArchitecture.WebApi.DIContainer.StartUp;

public static class ServiceCollection
{
    public static WebApplication ServiceConfiguration(this WebApplicationBuilder builder)
    {
        try
        {
            IConfiguration configuration = builder.Configuration;
            //Add services to the container.
            builder.Host.UseSerilog((context, service, configuration) =>
            {
                configuration.WriteTo.Console();
                configuration.WriteTo.File($"Log_{DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")}.log");
                configuration.WriteTo.File($"Log_{DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")}.txt");
            });
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddHttpContextAccessor();
            builder.Services.AddScoped<IUserManagement, UserManagement>();
            // Swagger Services
            builder.Services.AddSwaggerServiceConfiguration();


            builder.Services.AddApplicationContainer().AddInfrastructureContainer(configuration);
            builder.Services.AddAutoMapperProfiles(builder.Configuration, "AutoMapper");
            builder.Services.AddIdentityServiceConfiguration(configuration);



            return builder.Build();
        }
        catch (Exception)
        {
            throw;
        }
    }

    public static WebApplication PipLineConfiguration(this WebApplication app)
    {
        app.UseMiddleware<ExceptionMiddleware>();
        app.UseRouting();
        app.UseHttpsRedirection();

        /// Swagger Pipeline
        app.AddSwaggerServiceConfiguration();
        /// Identity Pipeline
        app.AddIdentityServiceConfiguration();

        app.MapControllers();
        return app;
    }
}

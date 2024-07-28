using CleanArchitecture.WebApi.Middlewares.ExceptionHandler;
using CleanArchitecture.WebApi.DIContainer.DependencyInjections;
using ObjectMapper.Implementations.Extensions.DependencyInjection;
using Serilog;

namespace CleanArchitecture.WebApi.DIContainer.StartUp;

public static class ServiceCollection
{
    public static WebApplication ServiceConfiguration(this WebApplicationBuilder builder)
    {
        try
        {
            IConfiguration configuration = builder.Configuration;
            // Add services to the container.
            builder.Host.UseSerilog();
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddApplicationContainer().AddInfrastructureContainer(configuration);
            builder.Services.AddAutoMapperProfiles(builder.Configuration, "AutoMapper");
            
            return builder.Build();
        }
        catch (Exception)
        {
            throw;
        }
    }

    public static WebApplication PipLineConfiguration(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        app.UseMiddleware<ExceptionMiddleware>();
        app.UseRouting();
        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();
        return app;
    }
}

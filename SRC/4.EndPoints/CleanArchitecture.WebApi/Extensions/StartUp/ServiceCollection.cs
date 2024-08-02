using CleanArchitecture.WebApi.Extensions.DependencyInjections;
using CleanArchitecture.WebApi.Extensions.Identity;
using CleanArchitecture.WebApi.Extensions.Identity.Extensions;
using CleanArchitecture.WebApi.Extensions.Swagger;
using CleanArchitecture.WebApi.Middlewares.ExceptionHandler;
using CleanArchitecture.WebApi.UserManagement.DependencyInjection;
using Microsoft.OpenApi.Models;
using ObjectMapper.Implementations.Extensions.DependencyInjection;
using Serilog;
using System.Text.Json.Serialization;

namespace CleanArchitecture.WebApi.Extensions.StartUp;

public static class ServiceCollection
{
    public static WebApplication ServiceConfiguration(this WebApplicationBuilder builder)
    {
        try
        {
            IConfiguration configuration = builder.Configuration;
            builder.Services.AddWebApiCore("CleanArchitecture");
            //Add services to the container.
            builder.Host.UseSerilog((context, service, configuration) =>
            {
                configuration.WriteTo.Console();
                configuration.WriteTo.File($"Log_{DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")}.log");
                configuration.WriteTo.File($"Log_{DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")}.txt");
            });

            builder.Services.AddApplicationContainer();

            builder.Services.AddInfrastructureContainer(configuration);

            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddControllers().AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve);

            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddAutoMapperProfiles(builder.Configuration, "AutoMapper");

            builder.Services.AddHttpContextAccessor();

            builder.Services.AddIdentityServiceConfiguration(configuration);

            builder.Services.AddUserManagement(false);

            // Swagger Services
            builder.Services.AddMvc();

            builder.Services.AddSwaggerExtension(configuration, "Swagger");

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
            app.UseDeveloperExceptionPage();
        }
        else
        {
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
        }
        app.UseMiddleware<ExceptionMiddleware>();
        
        app.UseHttpsRedirection();
        
        app.UseStaticFiles();

        app.UseRouting();

        app.UseIdentity();

        app.UseSwaggerUI("Swagger");

        app.MapControllers();
       
        return app;
    }
}

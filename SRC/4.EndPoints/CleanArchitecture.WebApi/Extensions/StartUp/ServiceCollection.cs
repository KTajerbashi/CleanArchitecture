using CleanArchitecture.WebApi.Extensions.DependencyInjections;
using CleanArchitecture.WebApi.Extensions.Identity;
using CleanArchitecture.WebApi.Extensions.Swagger;
using CleanArchitecture.WebApi.Middlewares.ExceptionHandler;
using CleanArchitecture.WebApi.UserManagement.DependencyInjection;
using Microsoft.AspNetCore.Cors.Infrastructure;
using ObjectMapper.Implementations.Extensions.DependencyInjection;
using Serilog;
using System.Reflection;
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

            builder.Services.AddUserManagement();

            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddControllers()
                .AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve);

            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddAutoMapperProfiles(builder.Configuration, "AutoMapper");


            builder.Services.AddHttpContextAccessor();


            builder.Services.AddAntiforgery(options =>
            {
                options.HeaderName = "X-CSRF-TOKEN";
            });


            builder.Services.AddIdentityServiceConfiguration(configuration);

            // Swagger Services
            builder.Services.AddMvc();

            builder.Services.AddSwaggerServiceConfiguration(configuration, "Swagger");


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
        app.UseStaticFiles();
        app.UseRouting();

        //app.UseSerilogRequestLogging();

        /// Swagger Pipeline
        app.UseSwaggerUI("Swagger");

        //app.UseStatusCodePages();

        //app.UseCors(delegate (CorsPolicyBuilder builder)
        //{
        //    builder.AllowAnyOrigin();
        //    builder.AllowAnyHeader();
        //    builder.AllowAnyMethod();
        //});
        //app.UseHttpsRedirection();

        /// Identity Pipeline
        app.UseIdentityServiceConfiguration();

        app.MapControllers();

        return app;
    }
}

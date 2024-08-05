using CleanArchitecture.Application.Extensions.DependencyInjections;
using CleanArchitecture.Infrastructure.Extensions.DependencyInjections;
using CleanArchitecture.WebApi.Extensions.ApiSettings;
using CleanArchitecture.WebApi.Extensions.Providers.Identity;
using CleanArchitecture.WebApi.Extensions.Providers.Swagger;
using CleanArchitecture.WebApi.Middlewares.ExceptionHandler;
using Microsoft.Net.Http.Headers;
using ObjectMapper.Implementations.Extensions.DependencyInjection;
using Serilog;
using BackgroundTaskProvider.HangfireProvider.Extension;
using System.Text.Json.Serialization;
using Hangfire;
using BackgroundTaskProvider.HangfireProvider.Filters;

namespace CleanArchitecture.WebApi.Extensions.StartupApplication;

public static class ServiceCollection
{
    public static WebApplication ServiceConfiguration(this WebApplicationBuilder builder)
    {
        try
        {
            IConfiguration configuration = builder.Configuration;

            //  Add All Web Application
            builder.Services.AddWebApiCore(configuration, "CleanArchitecture");

            builder.Services.AddDataAccess(configuration);

            builder.Services.AddApplicationServices();

            builder.Host.UseSerilog((context, service, configuration) =>
            {
                configuration.WriteTo.Console();
                configuration.WriteTo.File($"Log_{DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")}.log");
                configuration.WriteTo.File($"Log_{DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")}.txt");
            });

            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddControllers()
                //.AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve)
                ;

            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddAutoMapperProfiles(builder.Configuration, "AutoMapper");

            builder.Services.AddHttpContextAccessor();

            builder.Services.AddAuthorizationService(configuration);

            builder.Services.AddSwaggerExtension(configuration, "Swagger");

            builder.Services.AddHangfireService(configuration);

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

        app.UseHangfire();
        //app.UseHangfireDashboard("/hangfire", new DashboardOptions
        //{
        //    Authorization = new[] { new AuthenticationHangfireFilter() }
        //});
        app.UseSwaggerUI("Swagger");

        app.UseCors(policy =>
        {
            policy.WithOrigins(
                "http://localhost:7254",
                "https://localhost:7254")
            .AllowAnyMethod()
            .AllowAnyHeader()
            .WithHeaders(HeaderNames.ContentType);
        });

       
        app.MapControllers();

        return app;
    }
}

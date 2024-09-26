using CleanArchitecture.Application.Extensions.DependencyInjections;
using CleanArchitecture.Application.Providers.MapperProvider.DependencyInjection;
using CleanArchitecture.Infrastructure.Extensions.DependencyInjections;
using CleanArchitecture.WebApi.Extensions.DependencyInjection;
using CleanArchitecture.WebApi.Extensions.Providers.OAuth;
using CleanArchitecture.WebApi.Extensions.Providers.Serilog;
using CleanArchitecture.WebApi.Extensions.Providers.Swagger;
using CleanArchitecture.WebApi.Middlewares.ExceptionHandler;
using Microsoft.Net.Http.Headers;


namespace CleanArchitecture.WebApi.Extensions.StartupApplication;

public static class ServiceCollection
{
    public static WebApplication ServiceConfiguration(this WebApplicationBuilder builder)
    {
        try
        {
            IConfiguration configuration = builder.Configuration;
            
            builder.AddSerilogService(configuration);
            
            builder.Services.AddAutoMapperProfiles(configuration, "AutoMapper");

            builder.Services.AddWebApplicationService("CleanArchitecture");
            
            builder.Services.AddIdentityServices(configuration, "OAuth");

            builder.Services.AddDataAccess(configuration);

            builder.Services.AddApplicationServices();

            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddControllers();

            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddHttpContextAccessor();

            builder.Services.AddResponseCompression();

            builder.Services.AddSwaggerService(configuration, "Swagger");


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

        app.UseHsts().UseHttpsRedirection();

        app.UseHttpsRedirection();

        app.UseResponseCompression();

        app.UseStaticFiles();

        app.UseIdentity();

        app.UseRouting();

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
        app.MapFallbackToFile("index.html");
        return app;
    }
}

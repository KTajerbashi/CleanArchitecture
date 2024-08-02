﻿using CleanArchitecture.WebApi.Extensions.DependencyInjections;
using CleanArchitecture.WebApi.Extensions.Identity;
using CleanArchitecture.WebApi.Extensions.Identity.Extensions;
using CleanArchitecture.WebApi.Extensions.Swagger;
using CleanArchitecture.WebApi.Middlewares.ExceptionHandler;
using CleanArchitecture.WebApi.UserManagement.DependencyInjection;
using Microsoft.Net.Http.Headers;
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
          
            //  Add All Web Application
            builder.Services.AddWebApiCore("CleanArchitecture");
            
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

            builder.Services.AddUserManagement(configuration, false);

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
        //app.UseMiddleware<JwtMiddleware>();

        app.UseMiddleware<ExceptionMiddleware>();

        app.UseHttpsRedirection();

        app.UseStaticFiles();

        app.UseRouting();

        app.UseIdentity();

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

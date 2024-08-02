using CleanArchitecture.WebApi.Extensions.Swagger.Options;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using Swashbuckle.AspNetCore.SwaggerUI;
using System.Reflection;

namespace CleanArchitecture.WebApi.Extensions.Swagger;

public static class SwaggerExtension
{
    public static IServiceCollection AddSwaggerExtension(this IServiceCollection services, IConfiguration configuration, string sectionName)
    {
        services.AddSwaggerGen(option =>
        {
            option.AddSecurityDefinition("oauth2",new OpenApiSecurityScheme
            {
                In = ParameterLocation.Header,
                Name = "Authorization",
                Type = SecuritySchemeType.ApiKey
            });
            option.OperationFilter<SecurityRequirementsOperationFilter>();
        });
        return services;
    }
    //    public static IServiceCollection AddSwaggerExtension(this IServiceCollection services, IConfiguration configuration, string sectionName)
    //    {
    //        var profile = configuration.GetSection(sectionName).Get<SwaggerOption>();
    //        services.AddSwaggerGen(c =>
    //        {
    //            c.SwaggerDoc(
    //                profile.SwaggerDoc.Version, 
    //                new OpenApiInfo { 
    //                    Title = profile.SwaggerDoc.Title ,
    //                    Version = profile.SwaggerDoc.Version,
    //                    Description = profile.SwaggerDoc.Description,
    //                    TermsOfService = new Uri("https://example.com/terms"),
    //                    Contact = new OpenApiContact
    //                    {
    //                        Name = profile.SwaggerDoc.Contact.Name,
    //                        Email = profile.SwaggerDoc.Contact.Email,
    //                        Url = new Uri("https://github.com/KTajerbashi"),
    //                    },
    //                    License = new OpenApiLicense
    //                    {
    //                        Name = profile.SwaggerDoc.License.Name,
    //                        Url = new Uri(profile.SwaggerDoc.License.Url)
    //                    }
    //                });

    //            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    //            {
    //                Name = "Authorization",
    //                Type = SecuritySchemeType.ApiKey,
    //                Scheme = "Bearer",
    //                BearerFormat = "JWT",
    //                In = ParameterLocation.Header,
    //                Description = @"
    //JWT Authorization header using the Bearer scheme. 
    //Enter 'Bearer' [space] and then your token in the text input below.
    //Example: ""Bearer 12345abcde"""
    //            });

    //            c.AddSecurityRequirement(new OpenApiSecurityRequirement
    //            {
    //                {
    //                    new OpenApiSecurityScheme
    //                    {
    //                        Reference = new OpenApiReference
    //                        {
    //                            Type = ReferenceType.SecurityScheme,
    //                            Id = "Bearer"
    //                        }
    //                    },
    //                    new string[] {}
    //                }
    //            });

    //            var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    //            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    //            c.IncludeXmlComments(xmlPath);
    //        });

    //        return services;
    //    }
    public static void UseSwaggerUI(this WebApplication app, string sectionName)
    {
        var swaggerOption = app.Configuration.GetSection(sectionName).Get<SwaggerOption>();

        if (swaggerOption != null && swaggerOption.SwaggerDoc != null && swaggerOption.Enabled == true)
        {
            app.UseSwagger();
            app.UseSwaggerUI(option =>
            {
                option.DocExpansion(DocExpansion.None);
                option.SwaggerEndpoint(swaggerOption.SwaggerDoc.URL1, $"{swaggerOption.SwaggerDoc.Title} 1");
                option.SwaggerEndpoint(swaggerOption.SwaggerDoc.URL2, $"{swaggerOption.SwaggerDoc.Title} 2");
                option.RoutePrefix = "swagger";
            });
        }
    }
}

using Microsoft.OpenApi.Models;
using System.Reflection;

namespace CleanArchitecture.WebApi.Extensions.Providers.Swagger;

public static class SwaggerExtensions
{
    public static IServiceCollection AddSwaggerService(this IServiceCollection services,IConfiguration configuration,string sectionName)
    {
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Clean Architecture API",
                Version = "v1",
                Description = "An API To Perform Clean Architecture Operations",
                TermsOfService = new Uri("https://github.com/KTajerbashi/CleanArchitecture"),
                Contact = new OpenApiContact
                {
                    Name = "Kamran Tajerbashi",
                    Email = "KamranTajerbashi@gmail.com",
                    Url = new Uri("https://github.com/KTajerbashi/CleanArchitecture"),
                },
                License = new OpenApiLicense
                {
                    Name = "Clean Architecture API LICX",
                    Url = new Uri("https://github.com/KTajerbashi/CleanArchitecture"),
                }
            });
            // Set the comments path for the Swagger JSON and UI.
            var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            c.IncludeXmlComments(xmlPath);
        });
        return services;
    }
    public static void UseSwaggerUI(this WebApplication app,string sectionName)
    {
        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "Clean Architecture API V1");
        });
    }
}

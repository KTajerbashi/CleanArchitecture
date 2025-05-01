using CleanArchitecture.EndPoint.WebApi.Filters;
using Microsoft.OpenApi.Models;

namespace CleanArchitecture.EndPoint.WebApi.Providers;

public static class SwaggerExtensions
{
    public static IServiceCollection AddSwaggerService(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(c =>
        {
            // Explicitly set OpenAPI version (3.0.1 or higher)
            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Clean Architecture",
                Version = "v1",
                Description = "WebAPI using Swagger",
                Contact = new OpenApiContact
                {
                    Name = "Tajerbashi",
                    Email = "kamrantajerbashi@gmail.com",
                    Url = new Uri("https://github.com/KTajerbashi/CleanArchitecture.git")
                },
                // Optional: Explicitly declare OpenAPI spec version (meta-info only)
                TermsOfService = new Uri("https://example.com/terms"),
                License = new OpenApiLicense { Name = "MIT", Url = new Uri("https://opensource.org/licenses/MIT") }
            });

            // Add XML comments if available
            var xmlFile = $"{typeof(Program).Assembly.GetName().Name}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            if (File.Exists(xmlPath))
                c.IncludeXmlComments(xmlPath);

            // Add 401 response to all [Authorize] endpoints
            c.OperationFilter<UnauthorizedResponseOperationFilter>();

            // JWT Bearer Authentication
            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Name = "Authorization",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.Http,
                Scheme = "Bearer",
                BearerFormat = "JWT",
                Description = "JWT Authorization header using the Bearer scheme."
            });

            // Global security requirement
            c.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    Array.Empty<string>()
                }
            });

            // Optional: Sort endpoints alphabetically
            c.OrderActionsBy(apiDesc => $"{apiDesc.ActionDescriptor.RouteValues["controller"]}_{apiDesc.HttpMethod}");
        });

        return services;
    }

    public static WebApplication UseSwaggerService(this WebApplication app)
    {
        // Enable Swagger in all environments (not just Development)
        app.UseSwagger();
        app.UseSwaggerUI(options =>
        {
            options.SwaggerEndpoint("/swagger/v1/swagger.json", "WebAPI v1");
            options.RoutePrefix = string.Empty; // Access via /swagger/index.html
            options.DisplayRequestDuration(); // Show request duration
            options.EnableTryItOutByDefault(); // Enable "Try it out" by default
        });

        return app;
    }
}
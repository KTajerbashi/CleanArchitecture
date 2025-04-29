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
                }
            });

            // Add 401 response to all operations that have [Authorize]
            c.OperationFilter<UnauthorizedResponseOperationFilter>();

            // Configure security for API
            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                In = ParameterLocation.Header,
                Description = "Please enter a valid token",
                Name = "Authorization",
                Type = SecuritySchemeType.Http,
                BearerFormat = "JWT",
                Scheme = "Bearer"
            });

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
        });

        return services;
    }
    public static WebApplication UseSwaggerService(this WebApplication app)
    {
        // Enable Swagger in development mode
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "WebAPI v1");
                options.RoutePrefix = string.Empty; // Makes Swagger accessible at the root (e.g., http://localhost:5000)
            });
        }
        return app;
    }
}

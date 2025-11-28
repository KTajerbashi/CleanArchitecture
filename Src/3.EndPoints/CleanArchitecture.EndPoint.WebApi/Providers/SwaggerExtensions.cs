using CleanArchitecture.EndPoint.WebApi.Filters;
using Microsoft.OpenApi;

namespace CleanArchitecture.EndPoint.WebApi.Providers;

public static class SwaggerExtensions
{
    public static IServiceCollection AddSwaggerService(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();

        services.AddSwaggerGen(c =>
        {
            // Swagger document info
            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Clean Architecture WebAPI",
                Version = "v1",
                Description = "An example of Clean Architecture WebAPI with Swagger and JWT Authentication",
                Contact = new OpenApiContact
                {
                    Name = "Kamran Tajerbashi",
                    Email = "kamrantajerbashi@gmail.com",
                    Url = new Uri("https://github.com/KTajerbashi/CleanArchitecture.git")
                },
                TermsOfService = new Uri("https://example.com/terms"),
                License = new OpenApiLicense
                {
                    Name = "MIT",
                    Url = new Uri("https://opensource.org/licenses/MIT")
                }
            });

            // XML Comments
            var xmlFile = $"{typeof(Program).Assembly.GetName().Name}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            if (File.Exists(xmlPath))
                c.IncludeXmlComments(xmlPath);

            // JWT Bearer Security Definition
            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Name = "Authorization",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.Http,
                Scheme = "Bearer",
                BearerFormat = "JWT",
                Description = "Enter 'Bearer' followed by your JWT token. Example: 'Bearer abc123...'"
            });

            // Global Security Requirement for JWT
            c.AddSecurityRequirement(doc => new OpenApiSecurityRequirement());

            // Add global operation filter for 401 responses
            c.OperationFilter<UnauthorizedResponseOperationFilter>();

            // Optional: Sort endpoints alphabetically
            c.OrderActionsBy(apiDesc =>
                $"{apiDesc.ActionDescriptor.RouteValues["controller"]}_{apiDesc.HttpMethod}");

            // Optional: Use camelCase schema IDs
            c.CustomSchemaIds(type => type.FullName!.Replace("+", "."));
        });

        return services;
    }

    public static WebApplication UseSwaggerService(this WebApplication app)
    {
        app.UseSwagger();

        app.UseSwaggerUI(options =>
        {
            options.SwaggerEndpoint("/swagger/v1/swagger.json", "Clean Architecture WebAPI v1");
            options.RoutePrefix = "swagger"; // Access via /swagger
            options.DisplayRequestDuration();
            options.EnableTryItOutByDefault();
            options.DocExpansion(Swashbuckle.AspNetCore.SwaggerUI.DocExpansion.List); // Expand endpoints list
        });

        return app;
    }
}

namespace CleanArchitecture.EndPoint.WebApi.Providers;

public static class SwaggerExtensions
{
    public static IServiceCollection AddSwaggerService(this IServiceCollection services)
    {

        // Add Swagger services
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(options =>
        {
            // Add metadata for your API
            options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
            {
                Title = "Clean Architecture",
                Version = "v1",
                Description = "WebAPI using Swagger",
                Contact = new Microsoft.OpenApi.Models.OpenApiContact
                {
                    Name = "Tajerbashi",
                    Email = "kamrantajerbashi@gmail.com",
                    Url = new Uri("https://github.com/KTajerbashi/CleanArchitecture.git")
                }
            });

            // Configure security for API if needed
            //options.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
            //{
            //    In = Microsoft.OpenApi.Models.ParameterLocation.Header,
            //    Description = "Please enter a valid token",
            //    Name = "Authorization",
            //    Type = Microsoft.OpenApi.Models.SecuritySchemeType.Http,
            //    Scheme = "Bearer"
            //});

            //options.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
            //{
            //    {
            //        new Microsoft.OpenApi.Models.OpenApiSecurityScheme
            //        {
            //            Reference = new Microsoft.OpenApi.Models.OpenApiReference
            //            {
            //                Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme,
            //                Id = "Bearer"
            //            }
            //        },
            //        new List<string>()
            //    }
            //});
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

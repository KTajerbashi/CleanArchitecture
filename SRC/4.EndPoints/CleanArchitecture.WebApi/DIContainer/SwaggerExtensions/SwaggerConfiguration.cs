using Microsoft.OpenApi.Models;

namespace CleanArchitecture.WebApi.DIContainer.SwaggerExtensions;

public static class SwaggerConfiguration
{
    public static IServiceCollection AddSwaggerServiceConfiguration(this IServiceCollection services)
    {
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "CleanArchitecture", Version = "v1" });

            // Define the security scheme
            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Description = @"
                    JWT Authorization header using the Bearer scheme.  
                    Enter 'Bearer' [space] and then your token in the text input below.
                    Example: 'Bearer 12345abcdef'",
                Name = "Authorization",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.ApiKey,
                Scheme = "Bearer"
            });

            c.AddSecurityRequirement(new OpenApiSecurityRequirement()
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        },
                        Scheme = "oauth2",
                        Name = "Bearer",
                        In = ParameterLocation.Header,
                    },
                    new List<string>()
                }
            });
        });
        return services;
    }

    public static WebApplication AddSwaggerServiceConfiguration(this WebApplication app)
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

        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "CleanArchitecture API V1");
            c.RoutePrefix = "swagger";
        });

        return app;
    }
}

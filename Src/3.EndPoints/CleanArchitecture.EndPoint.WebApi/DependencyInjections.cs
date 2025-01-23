using CleanArchitecture.Core.Application.Library;
using CleanArchitecture.EndPoint.WebApi.Providers;
using CleanArchitecture.Infra.SqlServer.Library;

namespace CleanArchitecture.EndPoint.WebApi;

public static class DependencyInjections
{
    public static WebApplication WebApplicationBuilder(this WebApplicationBuilder builder)
    {
        IConfiguration configuration = builder.Configuration;

        builder.Services.AddInfrastructureLibrary(configuration);

        builder.Services.AddApplicationLibrary(configuration);
        
        builder.Services.AddControllers();
        
        builder.Services.AddOpenApi();

        builder.Services.AddSwaggerService();
        
        return builder.Build();
    }
    public static WebApplication WebApplication(this WebApplication app) 
    {
        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
        }
        app.UseSwaggerService();

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.MapFallbackToFile("index.html");

        return app;
    }

}

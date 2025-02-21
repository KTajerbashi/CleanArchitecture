using CleanArchitecture.Core.Application.Library;
using CleanArchitecture.Core.Application.Library.Utilities.Extensions;
using CleanArchitecture.EndPoint.WebApi.Providers;
using CleanArchitecture.Infra.SqlServer.Library;
using Serilog;

namespace CleanArchitecture.EndPoint.WebApi;

public static class DependencyInjections
{
    public static WebApplication WebApplicationBuilder(this WebApplicationBuilder builder)
    {
        IConfiguration configuration = builder.Configuration;

        builder.Host.UseSerilog((context, configuration) => configuration.ReadFrom.Configuration(context.Configuration));

        var assemblies = ("CleanArchitecture").GetAssemblies();

        builder.Services.AddApplicationLibrary(configuration, assemblies.ToArray());

        builder.Services.AddInfrastructureLibrary(configuration);

        builder.Services.AddControllers();
        
        builder.Services.AddOpenApi();

        builder.Services.AddSwaggerService();
        
        return builder.Build();
    }
    public static async Task<WebApplication> WebApplication(this WebApplication app) 
    {
        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
        }

        app.UseStaticFiles();
        
        app.UseSerilogRequestLogging();

        await Task.CompletedTask;
        app.ConfigureAwait(true);

        app.UseAuthentication();
        
        app.UseSession();

        app.UseAuthorization();

        app.UseSwaggerService();

        app.UseHttpsRedirection();

        app.MapControllers();

        app.MapFallbackToFile("index.html");

        return app;
    }

}

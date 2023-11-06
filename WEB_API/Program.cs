using Application.Library.DatabaseServices;
using Infrastructure.Library.DatabaseServices.SqlServer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using NLog.Web;
using Persistance.Library.EF.Identity;
using Persistance.Library.ProfileMapper;
using WEB_API.Services.ServiceInjection;

#pragma warning disable CS0618 // Type or member is obsolete
var builder = WebApplication.CreateBuilder(args);
ConfigurationManager configuration = builder.Configuration;
var logger = NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();
try
{

    // Add services to the container.
    builder.Services.AddAutoMapper(typeof(AutoMapperConfiguration));
    builder.Services.AddDbContext<IDatabaseRepository, ApplicationDatabase>(sql => sql.UseSqlServer(configuration.GetConnectionString("Default"))); ;
    builder.Services.AddControllers();
    builder.Services.AddScoped<ScopedServices>();
    //  Identity
    builder.Services.AddDbContext<ApplicationDatabase>(sql => sql.UseSqlServer(configuration.GetConnectionString("Authentication")));
    builder.Services
        .AddIdentity<AppUser, IdentityRole>()
        .AddEntityFrameworkStores<ApplicationDatabase>()
        .AddDefaultTokenProviders();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1", new OpenApiInfo
        {
            Title = "Architecture",
            Version = "v1",
            Description = "Clean Architecture Domain Drive Design Patter",
            TermsOfService = new Uri("https://github.com/Tajerbashi/Architecture"),
            Contact = new OpenApiContact
            {
                Name = "Kamran Tajerbashi",
                Email = "kamrantajerbashi@gmail.com",
                Url = new Uri("https://github.com/KTajerbashi"),
            },
            License = new OpenApiLicense
            {
                Name = "Tajerbashi Company On Git Hub",
                Url = new Uri("https://github.com/Tajerbashi"),
            }
        });
        c.SwaggerDoc("v2", new OpenApiInfo
        {
            Title = "Authentication",
            Version = "v2",
            Description = "Clean Architecture Domain Drive Design Patter",
            TermsOfService = new Uri("https://github.com/Tajerbashi/Architecture"),
            Contact = new OpenApiContact
            {
                Name = "Kamran Tajerbashi",
                Email = "kamrantajerbashi@gmail.com",
                Url = new Uri("https://github.com/KTajerbashi"),
            },
            License = new OpenApiLicense
            {
                Name = "Tajerbashi Company On Git Hub",
                Url = new Uri("https://github.com/Tajerbashi"),
            }
        });
    });

    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "Values Api V1");
            c.SwaggerEndpoint("/swagger/v2/swagger.json", "Values Api V2");
        });


    }
    app.UseStaticFiles();
    app.UseDeveloperExceptionPage();
    app.UseHttpsRedirection();
    //  Identity
    app.UseAuthentication();
    app.UseAuthorization();



    app.MapControllers();
    app.MapControllerRoute(
        name: "default",
        pattern: "service/{controller=Home}/{action=Index}/{id?}");
    app.Run();

}
catch (Exception exception)
{
    // NLog: catch setup errors
    logger.Error(exception, "Stopped program because of exception");
    throw;
}
finally
{
    // Ensure to flush and stop internal timers/threads before application-exit (Avoid segmentation fault on Linux)
    NLog.LogManager.Shutdown();
}
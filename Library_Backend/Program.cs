using Application.Library.Interfaces;
using Application.Library.Interfaces.Patterns.FacadPatterns;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Persistance.Library.DbContexts;
using Persistance.Library.ServiceRepository.FacadPattern;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddAutoMapper(typeof(Program));
//  AppSettings.json
var cstr = builder.Configuration.GetConnectionString("Default");
builder.Services.AddScoped<IDatabaseContext, DatabaseContext>();
builder.Services.AddSqlServer<DatabaseContext>(cstr);
//  Access To Appsetting.json
ConfigurationManager configuration = builder.Configuration;
// Add services to the container.
builder.Services.AddScoped<IFacadRepositories, FacadRepositories>();
builder.Services.AddControllers();
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
    // Set the comments path for the Swagger JSON and UI.
    //var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    ////var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    //c.IncludeXmlComments(xmlPath);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseStaticFiles();
}
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Home}/{action=Index}/{id?}");

//app.MapControllerRoute(
//  name: "Admin",
//  pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapDefaultControllerRoute();


app.Run();

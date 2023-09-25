using Application.Library.Interfaces;
using Application.Library.Interfaces.Patterns.FacadPatterns;
using EndPoint_WebApi.Middlewares;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Persistance.Library.DbContexts;
using Persistance.Library.MapperProfile;
using Persistance.Library.ServiceRepository.FacadPattern;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddAutoMapper(typeof(AutoMapperConfiguration));
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
    var filePath = Path.Combine(System.AppContext.BaseDirectory, "MyApi.xml");
    //c.IncludeXmlComments(filePath);
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Values Api V1");
    });
    app.UseStaticFiles();
}
app.UseHttpsRedirection();

app.UseAuthorization();
app.UseMiddleware<ErrorHandlerMiddleware>();
app.MapControllers();
app.MapDefaultControllerRoute();


app.Run();

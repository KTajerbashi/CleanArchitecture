using Application.Library.DatabaseServices;
using Application.Library.Validations.SEC;
using Domain.Library.Entities.SEC;
using FluentValidation;
using Infrastructure.Library.DatabaseServices.SqlServer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Persistance.Library.EF.Identity;
using Persistance.Library.ProfileMapper;
using System;

var builder = WebApplication.CreateBuilder(args);
ConfigurationManager configuration = builder.Configuration;

// Add services to the container.
builder.Services.AddAutoMapper(typeof(AutoMapperConfiguration));
builder.Services.AddDbContext<IDatabaseRepository, ApplicationDatabase>(sql => sql.UseSqlServer(configuration.GetConnectionString("Default"))); ;
builder.Services.AddControllers();
//  Fluent Validation
builder.Services.AddScoped<IValidator<User>, UserValidations>();
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
using Application.Library.Patterns.UnitOfWork;
using Infrastructure.Library.DatabaseContextApplication.EF;
using Infrastructure.Library.DatabaseContextApplication.ProfileMapper;
using Infrastructure.Library.Patterns.UnitOfWorks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;
using static System.Net.Mime.MediaTypeNames;

var builder = WebApplication.CreateBuilder(args);
ConfigurationManager configuration = builder.Configuration;
// Add services to the container.
builder.Services.AddAutoMapper(typeof(AutoMapperConfiguration));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(setup =>
{
    #region Doc1
    //setup.SwaggerDoc("v1", new OpenApiInfo
    //{
    //    Title = "Architecture",
    //    Version = "v1",
    //    Description = "Clean Architecture Domain Drive Design Patter",
    //    TermsOfService = new Uri("https://github.com/Tajerbashi/Architecture"),
    //    Contact = new OpenApiContact
    //    {
    //        Name = "Kamran Tajerbashi",
    //        Email = "kamrantajerbashi@gmail.com",
    //        Url = new Uri("https://github.com/KTajerbashi"),
    //    },
    //    License = new OpenApiLicense
    //    {
    //        Name = "Tajerbashi Company On Git Hub",
    //        Url = new Uri("https://github.com/Tajerbashi"),
    //    }
    //});
    #endregion

    #region Doc2
    //setup.SwaggerDoc("v2", new OpenApiInfo
    //{
    //    Title = "Authentication",
    //    Version = "v2",
    //    Description = "Clean Architecture Domain Drive Design Patter",
    //    TermsOfService = new Uri("https://github.com/Tajerbashi/Architecture"),
    //    Contact = new OpenApiContact
    //    {
    //        Name = "Kamran Tajerbashi",
    //        Email = "kamrantajerbashi@gmail.com",
    //        Url = new Uri("https://github.com/KTajerbashi"),
    //    },
    //    License = new OpenApiLicense
    //    {
    //        Name = "Tajerbashi Company On Git Hub",
    //        Url = new Uri("https://github.com/Tajerbashi"),
    //    }
    //});
    #endregion

    #region JWT
    //var jwtSecurityScheme = new OpenApiSecurityScheme
    //{
    //    BearerFormat = "JWT",
    //    Name = "JWT Authentication",
    //    In = ParameterLocation.Header,
    //    Type = SecuritySchemeType.Http,
    //    Scheme = JwtBearerDefaults.AuthenticationScheme,
    //    Description = "Put **_ONLY_** your JWT Bearer token on textbox below!",

    //    Reference = new OpenApiReference
    //    {
    //        Id = JwtBearerDefaults.AuthenticationScheme,
    //        Type = ReferenceType.SecurityScheme
    //    }
    //};
    //setup.AddSecurityDefinition(jwtSecurityScheme.Reference.Id, jwtSecurityScheme);
    //setup.AddSecurityRequirement(new OpenApiSecurityRequirement
    //{
    //    { jwtSecurityScheme, Array.Empty<string>() }
    //});
    #endregion

    #region Auth
    //setup.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    //{
    //    Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n 
    //                  Enter 'Bearer' [space] and then your token in the text input below.
    //                  \r\n\r\nExample: 'Bearer 12345abcdef'",
    //    Name = "Authorization",
    //    In = ParameterLocation.Header,
    //    Type = SecuritySchemeType.ApiKey,
    //    Scheme = "Bearer"
    //});

    //setup.AddSecurityRequirement(new OpenApiSecurityRequirement()
    //  {
    //    {
    //      new OpenApiSecurityScheme
    //      {
    //        Reference = new OpenApiReference
    //          {
    //            Type = ReferenceType.SecurityScheme,
    //            Id = "Bearer"
    //          },
    //          Scheme = "oauth2",
    //          Name = "Bearer",
    //          In = ParameterLocation.Header,

    //        },
    //        new List<string>()
    //      }
    //    });
    //var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    //var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    //setup.IncludeXmlComments(xmlPath);
    #endregion

    #region Secure SW UI
    setup.SwaggerDoc("v1", new OpenApiInfo {
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
    setup.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter a valid token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
    setup.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new string[]{}
        }
    });
    #endregion
});
builder.Services.AddDbContext<DBContextApplication>(sql => sql.UseSqlServer(configuration.GetConnectionString("ConnectionString")));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

//  Authentication Services
builder.Services.AddAuthentication(option =>
{
    option.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    option.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    option.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
}).AddCookie(option =>
{
    option.LoginPath = new PathString("/Authentication/Signin");
    option.ExpireTimeSpan = TimeSpan.FromMinutes(5.0);
    option.AccessDeniedPath = new PathString("/Authentication/Signin");
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Architecture Api V1");
        c.SwaggerEndpoint("/swagger/v2/swagger.json", "Authentication Api V2");
    });

    app.UseExceptionHandler(exceptionHandlerApp =>
    {
        exceptionHandlerApp.Run(async context =>
        {
            context.Response.StatusCode = StatusCodes.Status500InternalServerError;

            // using static System.Net.Mime.MediaTypeNames;
            context.Response.ContentType = Text.Plain;

            await context.Response.WriteAsync("An exception was thrown.");

            var exceptionHandlerPathFeature =
                context.Features.Get<IExceptionHandlerPathFeature>();

            if (exceptionHandlerPathFeature?.Error is FileNotFoundException)
            {
                await context.Response.WriteAsync(" The file was not found.");
            }

            if (exceptionHandlerPathFeature?.Path == "/")
            {
                await context.Response.WriteAsync(" Page: Home.");
            }
        });
    });
}
app.UseHsts();
app.UseHttpsRedirection();

app.UseStatusCodePagesWithRedirects("/StatusCode/{0}");

//app.UseStatusCodePages();
//app.UseStatusCodePages(Text.Plain, "Status Code Page: {0}");
app.UseStatusCodePages(async statusCodeContext =>
{
    // using static System.Net.Mime.MediaTypeNames;
    statusCodeContext.HttpContext.Response.ContentType = Text.Plain;

    await statusCodeContext.HttpContext.Response.WriteAsync(
        $"Status Code Page: {statusCodeContext.HttpContext.Response.StatusCode}");
});
app.UseAuthentication();

app.UseAuthorization();
app.MapControllers();

app.Run();

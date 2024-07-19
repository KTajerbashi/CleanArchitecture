using CleanArchitecture.Infrastructure.DIContainer;
using CleanArchitecture.Application.DIContainer;
using CleanArchitecture.WebApi.Middlewares.ExceptionHandler;
using ObjectMapper.Implementations.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddApplicationServices();
builder.Services.AddDataAccess(builder.Configuration);

builder.Services.AddAutoMapperProfiles(builder.Configuration, "AutoMapper");
var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseMiddleware<ExceptionMiddleware>();
app.UseRouting();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

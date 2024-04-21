using Identity.Library.BackgroundTaskServices.Consumers.Services;
using Identity.Library.BackgroundTaskServices.Producers.Services;
using Identity.Library.BackgroundTaskServices.Queues.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IBackgroundTaskQueue>(p =>
{
    return new BackgroundTaskQueue(5);
});
builder.Services.AddSingleton<CreatePdfFile>();
builder.Services.AddHostedService<QueuedHostedService>();
//builder.Services.AddHostedService<SendEmail>();

//builder.Services.AddHostedService<BackgroundTaskService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

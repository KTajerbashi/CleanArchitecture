using CleanArchitecture.WebApp.AppSettings;
using CleanArchitecture.WebApp.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);
ConfigurationManager Configuration = builder.Configuration;
var appSetting = Configuration.Get<AppSetting>();

builder.Services.AddDatabaseContext(appSetting.ConnectionStrings.DefaultConnection);
builder.Services.AddIdentity();
builder.Services.AddClaims();
builder.Services.AddPolicy();
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddControllers();


var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.MapControllers();
app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();

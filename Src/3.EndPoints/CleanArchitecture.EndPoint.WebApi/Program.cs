using CleanArchitecture.EndPoint.WebApi;

try
{
    var builder = WebApplication.CreateBuilder(args).WebApplicationBuilder();
    Log.Information("Start Application ...");
    var app = await builder.ConfigurePipeline();
    Log.Information("Application Running ...");
    await app.RunAsync();
}
catch
{
    Log.Fatal(string.Format("Application Down : {0}", DateTime.Now));
    await Log.CloseAndFlushAsync();
    throw;
}

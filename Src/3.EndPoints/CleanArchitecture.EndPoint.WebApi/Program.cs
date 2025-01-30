using CleanArchitecture.EndPoint.WebApi;

var builder = WebApplication.CreateBuilder(args).WebApplicationBuilder();
var app = await builder.WebApplication();
await app.RunAsync();

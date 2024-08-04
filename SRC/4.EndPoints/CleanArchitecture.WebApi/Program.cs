using CleanArchitecture.WebApi.Extensions.StartupApplication;

StartUpApplication.StartApplication(() =>
{
    WebApplication
            .CreateBuilder(args)
            .ServiceConfiguration()
            .PipLineConfiguration()
            .Run();
});

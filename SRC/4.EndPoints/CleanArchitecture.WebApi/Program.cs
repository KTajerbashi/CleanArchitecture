using CleanArchitecture.WebApi.Extensions;

StartUpApplication.StartApplication(() =>
{
    WebApplication
            .CreateBuilder(args)
            .ServiceConfiguration()
            .PipLineConfiguration()
            .Run();
});

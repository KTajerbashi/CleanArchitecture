using CleanArchitecture.WebApi.Extensions;
using CleanArchitecture.WebApi.Extensions.StartUp;

StartUpApplication.StartApplication(() =>
{
    WebApplication
            .CreateBuilder(args)
            .ServiceConfiguration()
            .PipLineConfiguration()
            .Run();
});

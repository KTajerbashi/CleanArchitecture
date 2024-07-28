using CleanArchitecture.WebApi.DIContainer;
using CleanArchitecture.WebApi.DIContainer.StartUp;

StartUpApplication.StartApplication(() =>
{
    WebApplication
            .CreateBuilder(args)
            .ServiceConfiguration()
            .PipLineConfiguration()
            .Run();
});

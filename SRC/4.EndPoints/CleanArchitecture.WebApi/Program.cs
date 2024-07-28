using CleanArchitecture.WebApi.DIContainer;
using CleanArchitecture.WebApi.DIContainer.StartUp;

SeriLogExtension.StartApplication(() =>
{
    WebApplication
            .CreateBuilder(args)
            .ServiceConfiguration()
            .PipLineConfiguration()
            .Run();
});

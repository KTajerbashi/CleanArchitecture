namespace CleanArchitecture.EndPoint.WebApi.Providers.Excel;

public static class DependencyInjection
{
    public static IServiceCollection AddEPPlusExcelSerializer(this IServiceCollection services)
        => services.AddSingleton<IExcelSerializer, EPPlusExcelSerializer>();
}
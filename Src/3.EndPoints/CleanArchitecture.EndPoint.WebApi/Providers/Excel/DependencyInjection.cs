namespace CleanArchitecture.Core.Application.Library.Providers.Serializer.Excel;

public static class DependencyInjection
{
    public static IServiceCollection AddEPPlusExcelSerializer(this IServiceCollection services)
        => services.AddSingleton<IExcelSerializer, EPPlusExcelSerializer>();
}
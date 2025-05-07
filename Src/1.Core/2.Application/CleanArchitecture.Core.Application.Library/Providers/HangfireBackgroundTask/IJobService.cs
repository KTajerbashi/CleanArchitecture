using CleanArchitecture.Core.Application.Library.Providers.Scrutor;

namespace CleanArchitecture.Core.Application.Library.Providers.HangfireBackgroundTask;

public interface IJobService : IScopeLifeTime
{
    void CreateDefaultUserRole();
    void UpdatePhonesFromWebService();
    void RemoveDataExpire();
    void SendEmail();


    void CreateOrderById(int orderId);
    void UpdateOrderById(int orderId);
    void RemoveOrderById(int orderId);
    void ReadData(int orderId);
}
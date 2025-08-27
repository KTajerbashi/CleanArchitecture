using CleanArchitecture.Core.Application.Providers.HangfireBackgroundTask;
using CleanArchitecture.Core.Application.Utilities.Extensions;

namespace CleanArchitecture.Infra.SqlServer.Providers.HangfireBackgroundTask;

public class JobService : IJobService
{
    public void CreateDefaultUserRole()
    {
        ConsoleWriterExtension.PrintConsole($"~> Start CreateDefaultUserRole On {DateTime.Now.ToString("G")}");
        Task.Delay(5000);
        ConsoleWriterExtension.PrintConsole($"~> Finish CreateDefaultUserRole On {DateTime.Now.ToString("G")}");
    }

    public void RemoveDataExpire()
    {
        ConsoleWriterExtension.PrintConsole($"~> Start RemoveDataExpire On {DateTime.Now.ToString("G")}");
        Task.Delay(5000);
        ConsoleWriterExtension.PrintConsole($"~> Finish RemoveDataExpire On {DateTime.Now.ToString("G")}");
    }

    public void SendEmail()
    {
        ConsoleWriterExtension.PrintConsole($"~> Start SendEmail On {DateTime.Now.ToString("G")}");
        Task.Delay(5000);
        ConsoleWriterExtension.PrintConsole($"~> Finish SendEmail On {DateTime.Now.ToString("G")}");
    }

    public void UpdatePhonesFromWebService()
    {
        ConsoleWriterExtension.PrintConsole($"~> Start UpdatePhonesFromWebService On {DateTime.Now.ToString("G")}");
        Task.Delay(5000);
        ConsoleWriterExtension.PrintConsole($"~> Finish UpdatePhonesFromWebService On {DateTime.Now.ToString("G")}");
    }


    public void CreateOrderById(int orderId)
    {
        ConsoleWriterExtension.PrintConsole($"~> Create Order By Id {orderId} Started On :{DateTime.Now.ToString("G")}");
        Task.Delay(3000);
        ConsoleWriterExtension.PrintConsole($"~> Create Order By Id {orderId} Finished On :{DateTime.Now.ToString("G")}");
    }

    public void UpdateOrderById(int orderId)
    {
        ConsoleWriterExtension.PrintConsole($"~> Update Order By Id {orderId} Started On :{DateTime.Now.ToString("G")}");
        Task.Delay(3000);
        ConsoleWriterExtension.PrintConsole($"~> Update Order By Id {orderId} Finished On :{DateTime.Now.ToString("G")}");
    }

    public void RemoveOrderById(int orderId)
    {
        ConsoleWriterExtension.PrintConsole($"~> Remove Order By Id {orderId} Started On :{DateTime.Now.ToString("G")}");
        Task.Delay(3000);
        ConsoleWriterExtension.PrintConsole($"~> Remove Order By Id {orderId} Finished On :{DateTime.Now.ToString("G")}");
    }

    public void ReadData(int orderId)
    {
        ConsoleWriterExtension.PrintConsole($"~> Read Order By Id {orderId} Started On :{DateTime.Now.ToString("G")}");
        Task.Delay(3000);
        ConsoleWriterExtension.PrintConsole($"~> Read Order By Id {orderId} Finished On :{DateTime.Now.ToString("G")}");
    }

}

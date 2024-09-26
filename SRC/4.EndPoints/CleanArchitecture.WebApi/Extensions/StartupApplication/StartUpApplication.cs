namespace CleanArchitecture.WebApi.Extensions.StartupApplication;

public class StartUpApplication
{
    public static void StartApplication(Action action)
    {

        try
        {
            action();
        }
        catch (Exception ex)
        {
        }
        finally
        {
        }
    }
}

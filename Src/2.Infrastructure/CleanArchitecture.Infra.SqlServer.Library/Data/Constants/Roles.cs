namespace CleanArchitecture.Infra.SqlServer.Library.Data.Constants;

public static class Roles
{
    public static string Administrator => nameof(Administrator);
}

public abstract class Policies
{
    public const string CanPurge = nameof(CanPurge);
}
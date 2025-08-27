namespace CleanArchitecture.Infra.SqlServer.Data.Constants;

public static class Roles
{
    public static string Administrator => nameof(Administrator);
    public static string User => nameof(User);
    public static string ContentManager => nameof(ContentManager);

    public static IEnumerable<string> GetAll()
    {
        return typeof(Roles).GetFields(BindingFlags.Public | BindingFlags.Static)
            .Where(f => f.FieldType == typeof(string))
            .Select(f => (string)f.GetValue(null));
    }
}

public abstract class Policies
{
    public const string CanPurge = nameof(CanPurge);
    public const string AdminAccess = nameof(AdminAccess);
    public const string UserAccess = nameof(UserAccess);
    public static string ContentManager => nameof(ContentManager);

    public static IEnumerable<string> GetAll()
    {
        return typeof(Policies).GetFields(BindingFlags.Public | BindingFlags.Static)
            .Where(f => f.FieldType == typeof(string))
            .Select(f => (string)f.GetValue(null));
    }
}
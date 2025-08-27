using CleanArchitecture.Core.Application.Utilities.Guards;

namespace CleanArchitecture.Core.Application.Utilities.Guards.GuardClauses;

public static class NotEqualGuardClause
{
    public static void NotEqual<T>(this Guard guard, T value, T targetValue, string message)
    {
        if (string.IsNullOrEmpty(message))
            throw new ArgumentNullException("Message");

        if (Equals(value, targetValue))
            throw new InvalidOperationException(message);
    }
}
using CleanArchitecture.Core.Application.Utilities.Guards;
using System.Text.RegularExpressions;

namespace CleanArchitecture.Core.Application.Utilities.Guards.GuardClauses;

public static class MatchGuardClause
{
    public static void Match(this Guard guard, string value, string pattern, string message)
    {
        if (string.IsNullOrEmpty(message))
            throw new ArgumentNullException("Message");

        if (!Regex.IsMatch(value, pattern))
            throw new InvalidOperationException(message);
    }
}
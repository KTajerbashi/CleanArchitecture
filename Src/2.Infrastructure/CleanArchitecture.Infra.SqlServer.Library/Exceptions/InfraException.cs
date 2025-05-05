using CleanArchitecture.Core.Domain.Library.Exceptions;

namespace CleanArchitecture.Infra.SqlServer.Library.Exceptions;

public class InfraException : BaseException
{
    public InfraException(string message, params string[] parameters) : base(message, parameters)
    {
    }
}
public class IdentityException : InfraException
{
    public IEnumerable<string> Errors { get; }
    public string Message { get; set; }

    public IdentityException(IEnumerable<IdentityError> errors)
        : base("Identity operation failed")
    {
        Errors = errors.Select(e => e.Description);
    }

    public IdentityException(string error)
        : base("Identity operation failed")
    {
        Errors = new List<string> { error };
    }
}
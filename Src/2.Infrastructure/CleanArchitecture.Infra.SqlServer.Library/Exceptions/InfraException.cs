using CleanArchitecture.Core.Domain.Library.Exceptions;

namespace CleanArchitecture.Infra.SqlServer.Library.Exceptions;

public class InfraException : BaseException
{
    public InfraException(string message, params string[] parameters) : base(message, parameters)
    {
    }
}

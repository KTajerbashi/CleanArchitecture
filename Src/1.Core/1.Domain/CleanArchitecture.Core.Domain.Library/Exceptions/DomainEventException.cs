namespace CleanArchitecture.Core.Domain.Library.Exceptions;

public class DomainEventException : BaseException
{
    public DomainEventException(string message, params string[] parameters) : base(message, parameters)
    {
    }
}

namespace CleanArchitecture.Core.Domain.Exceptions;

public class DomainEventException : BaseException
{
    public DomainEventException(string message, params string[] parameters) : base(message, parameters)
    {
    }
}

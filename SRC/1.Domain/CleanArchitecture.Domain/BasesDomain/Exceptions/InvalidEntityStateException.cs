namespace CleanArchitecture.Domain.BasesDomain.Exceptions;

public class InvalidEntityStateException : DomainStateException
{
    public InvalidEntityStateException(string message, params string[] parameters) : base(message, parameters)
    {
    }
}

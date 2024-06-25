namespace CleanArchitecture.Domain.Exceptions;

public class InvalidValueObjectStateException : DomainStateException
{
    public InvalidValueObjectStateException(string message, params string[] parameters) : base(message, parameters)
    {
    }
}

namespace CleanArchitecture.Domain.Exceptions;

public class InvalidApplicationServiceStateException : DomainStateException
{
    public InvalidApplicationServiceStateException(string message, params string[] parameters) : base(message, parameters)
    {
    }
}
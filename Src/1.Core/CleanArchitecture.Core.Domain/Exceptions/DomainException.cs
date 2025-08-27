namespace CleanArchitecture.Core.Domain.Exceptions;


public class DomainException : BaseException
{
    public DomainException(string message, params string[] parameters) : base(message, parameters)
    {
    }
}

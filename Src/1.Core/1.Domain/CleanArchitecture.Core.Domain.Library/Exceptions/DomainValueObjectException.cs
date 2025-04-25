namespace CleanArchitecture.Core.Domain.Library.Exceptions;

public class DomainValueObjectException : BaseException
{
    public DomainValueObjectException(string message, params string[] parameters) : base(message, parameters)
    {
    }
}
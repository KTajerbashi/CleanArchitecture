namespace CleanArchitecture.Core.Domain.Library.Exceptions;


public class DomainException : BaseException
{
    public DomainException(string message, params string[] parameters) : base(message, parameters)
    {
    }
}

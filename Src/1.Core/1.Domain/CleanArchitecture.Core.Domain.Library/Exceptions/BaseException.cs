namespace CleanArchitecture.Core.Domain.Library.Exceptions;

public class BaseException : Exception
{
    public string[] Parameters { get; set; }
    public BaseException(string message, params string[] parameters) : base(message)
    {
        Parameters = parameters;

    }
    public BaseException(string msg) : base(msg) { }
    public BaseException(string msg, Exception exception) : base(msg, exception) { }
    public BaseException(Exception exception) : base(exception.Message, exception) { }

    public override string ToString()
    {

        if (Parameters is null) return Message;
        if (Parameters?.Length < 1)
            return Message;


        string result = Message;

        for (int i = 0; i < Parameters.Length; i++)
        {
            string placeHolder = $"{{{i}}}";
            result = result.Replace(placeHolder, Parameters[i]);
        }

        return result;
    }
}

namespace CleanArchitecture.WebApi.Models;

public class _JsonResult
{
    public static _JsonResult<T> Success<T>(T data)
    {
        return new _JsonResult<T>()
        {
            Data = data,
            Error = null,
            Message = "عملیات با موفقیت انجام گردید.",
            Success = true,
            Token = ""
        };
    }

}

public class _JsonResult<T> : _JsonResult
{
    public bool Success { get; set; }
    public T Data { get; set; }
    public string Message { get; set; }
    public Exception Error { get; set; }
    public string Token { get; set; }
}
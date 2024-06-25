namespace CleanArchitecture.Application.BaseApplication.Models.Query;

public interface IQueryModel
{
}

public interface IBaseQuery
{
    string Message { get; set; }
    bool IsSuccess { get; set; }
}

public class BaseQueryResult<TData> : IBaseQuery
{
    public TData Data { get; set; }
    public string Message { get; set; }
    public bool IsSuccess { get; set; }
}

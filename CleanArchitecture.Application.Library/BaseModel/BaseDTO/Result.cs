namespace CleanArchitecture.Application.Library.BaseModel.BaseDTO
{
    public class Result<T> : IResult<T>
    {
        public bool Status { get; set; }
        public string Message { get; set; }
        public T? Data { get; set; }
        public int StatusCode { get; set; }
    }

}

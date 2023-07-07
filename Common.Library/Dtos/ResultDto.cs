namespace Common.Library
{
    public class ResultDto<T> : DTO
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
    }
}

namespace Common.Library
{
    public interface IResultDTO
    {
        bool Success { get; set; }
        string Message { get; set; }
    }
    public class ResultDTO<T> : IResultDTO
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
    }
}

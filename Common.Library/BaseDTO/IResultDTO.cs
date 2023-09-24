using System;

namespace Common.Library
{
    public interface IResultDTO
    {
        bool Success { get; set; }
        string Message { get; set; }
    }
    public class ResultDTO : IResultDTO
    {
        public bool Success { get; set; }
        public string Message { get; set; }
    }
    public class ResultDTO<T> : ResultDTO
    {
        public T Data { get; set; }
    }
}

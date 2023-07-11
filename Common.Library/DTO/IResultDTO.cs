using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Library
{
    public interface IResultDTO
    {
    }
    public class ResultDTO : IResultDTO
    {
        public bool IsSuccess { get; set; }
        public string? Message { get; set; }
    }
    public class ResultDTO<T> : IResultDTO
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
    }
}

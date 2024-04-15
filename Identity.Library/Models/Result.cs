using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Identity.Library.Models
{
    public sealed class ResultModel<T>
    {
        public T Data { get; set; }
        public object? Result { get; set; }
        public string Message { get; set; }
        public StatusCodeResult StatusCode { get; set; }
    }
}

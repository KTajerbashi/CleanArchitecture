using System.Security.Claims;

namespace Identity.Library.Models
{
    public sealed class ResultModel<T>
    {
        public T Data { get; set; }
        public int StatusCode { get; set; }
        public string Message { get; set; }
    }
    public class User
    {
        public string SubjectId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public List<Claim> Claims { get; set; }
    }
}

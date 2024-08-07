namespace EmailProvider.Oragnization.Models
{
    public class EmailOption
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string TextMessage { get; set; }
        public string ContactNumber { get; set; }
    }

    public class EmailResult
    {
        public string ContactNumber { get; set; }
        public bool IsSuccess { get; set; }
    }
}
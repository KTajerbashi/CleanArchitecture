namespace Application.Library.Service
{
    public class RequestDTO
    {
        public RequestDTO() { }
        public long ID { get; set; }
        public long? ParentId { get; set; }
        public string Name { get; set; }
    }
}

namespace Committees.Models
{
    public class Attachment : AuditEntity<Guid>
    {
        public string? Path { get; set; }
    }
}
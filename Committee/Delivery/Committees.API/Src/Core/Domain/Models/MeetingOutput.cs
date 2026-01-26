namespace Committees.Domain.Models
{
    public class MeetingOutput : AuditEntity<Guid>
    {
        public Guid MeetingId { get; set; }
        public Meeting Meeting { get; set; }
        public Guid OutputId { get; set; }
        public Output Output { get; set; }
    }
}

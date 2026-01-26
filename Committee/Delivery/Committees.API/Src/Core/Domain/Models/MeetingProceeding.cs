namespace Committees.Domain.Models
{
    public class MeetingProceeding : AuditEntity<Guid>
    {
        public Guid MeetingId { get; set; }
        public Meeting Meeting { get; set; }
        public Guid ProceedingId { get; set; }
        public Proceeding Proceeding { get; set; }
    }
}

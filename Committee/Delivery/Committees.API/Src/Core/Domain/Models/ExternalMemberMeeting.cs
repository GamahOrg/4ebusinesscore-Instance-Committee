namespace Committees.Domain.Models
{
    public class ExternalMemberMeeting : AuditEntity<Guid>
    {
        public Guid ExternalMemberId { get; set; }
        public ExternalMember ExternalMember { get; set; }
        public Guid MeetingId { get; set; }
        public Meeting Meeting { get; set; }
    }
}

namespace Committees.Domain.Models
{
    public class InternalMemberMeeting : AuditEntity<Guid>
    {
        public Guid InternalMemberId { get; set; }
        public InternalMember InternalMember { get; set; }
        public Guid MeetingId { get; set; }
        public Meeting Meeting { get; set; }
    }
}

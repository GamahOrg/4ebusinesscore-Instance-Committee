namespace Committees.Models
{
    public class ExternalMember : AuditEntity<Guid>
    {
        public string? Name { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Job { get; set; }
        public string? DestinationName { get; set; }
        public string? Email { get; set; }
        public Guid PermissionId { get; set; }
        public Permission Permission { get; set; }
        public Guid CommitteeId { get; set; }
        public Committee Committee { get; set; }
        public ICollection<ExternalMemberProceeding> ExternalMemberProceedings { get; set; }
        public virtual ICollection<ExternalMemberMeeting> ExternalMemberMeetings { get; set; }
    }
}

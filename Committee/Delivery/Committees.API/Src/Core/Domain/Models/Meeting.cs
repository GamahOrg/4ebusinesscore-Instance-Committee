namespace Committees.Models
{
    public class Meeting : AuditEntity<Guid>
    {
        public string? Rules { get; set; }
        public string? Name { get; set; }
        public string? Location { get; set; }
        public MeetingStatus MeetingStatus { get; set; }
        public bool HasExpertAssist { get; set; }
        public DateTime MeetingDate { get; set; }
        public Guid CommitteeId { get; set; }
        public Committee Committee { get; set; }
        public virtual ICollection<MeetingAttachment> MeetingAttachments { get; set; }
        public virtual ICollection<MeetingProceeding> MeetingProceedings { get; set; }
        public virtual ICollection<MeetingOutput> MeetingOutputs { get; set; }
        public virtual ICollection<ExternalMemberMeeting> ExternalMemberMeetings { get; set; }
        public virtual ICollection<InternalMemberMeeting> InternalMemberMeetings { get; set; }
    }
}

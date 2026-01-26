namespace Committees.Domain.Models
{
    public class Output : AuditEntity<Guid>
    {
        public string? Name { get; set; }
        //public Guid OutputTypeId { get; set; }
        //public OutputType OutputType { get; set; }
        public string? Details { get; set; }
        public int OutputNumber { get; set; }
        public ICollection<OutputAttachment> OutputAttachments { get; set; }
        public ICollection<MeetingOutput> MeetingOutputs { get; set; }
        public Guid CommitteeId { get; set; }
        public Committee Committee { get; set; }
    }
}

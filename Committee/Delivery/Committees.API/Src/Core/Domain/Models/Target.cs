namespace Committees.Domain.Models
{
    public class Target : AuditEntity<Guid>
    {
        public string? Goal { get; set; }
        public Guid CommitteeId { get; set; }
        public Committee Committee { get; set; }
    }
}

namespace Committees.Domain.Models
{
    public class InternalMemberProceeding : AuditEntity<Guid>
    {
        public Guid InternalMemberId { get; set; }
        public InternalMember InternalMember { get; set; }
        public Guid ProceedingId { get; set; }
        public Proceeding Proceeding { get; set; }
        public bool IsAttend { get; set; }
        public int ProceedingAcceptance { get; set; }
        public string? AcceptanceMessage { get; set; }
    }
}

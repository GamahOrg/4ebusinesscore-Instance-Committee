namespace Committees.Models
{
    public class Committee : AuditEntity<Guid>
    {
        public string? Name { get; set; }
        public DateTime CommitteeDate { set; get; }
        public int CommitteeTime { get; set; }
        public DateTime? EndDateCommittee { set; get; }
        public string? ProjectName { get; set; }
        public bool HasLegalDocument { get; set; }
        public string? WorkRule { get; set; }
        public string? LegalDocument { get; set; }
        public string? Missions { get; set; }
        public CommitteesStatus CommitteesStatus { get; set; }
        public string? Notes { get; set; }
        public Guid? RequestInstanceId { get; set; }
        public RequestStatus? RequestStatus { get; set; }
        public virtual ICollection<Meeting> Meetings { get; set; }
        public virtual ICollection<CommitteeAttachment>? Attachments { get; set; }
        public virtual ICollection<WorkRule>? WorkRules { get; set; }
        public virtual ICollection<ExternalMember>? ExternalMembers { get; set; }
        public virtual ICollection<CommitteeInternalMember> CommitteeInternalMembers { get; set; }
        public virtual ICollection<Proceeding> Proceedings { get; set; }
        public virtual ICollection<Output> Outputs { get; set; }
        public virtual ICollection<Target> Targets { get; set; }
        public long CommitteeNumber { get; set; }


    }
}

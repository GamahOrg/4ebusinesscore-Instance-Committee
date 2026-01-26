namespace Committees.Domain.Models
{
    public class OutputType : AuditEntity<Guid>
    {
        public string? NameAr { get; set; }
        public string? NameEn { get; set; }
        public string? Description { get; set; }
        public string? CSSClasses { get; set; }
    }
}

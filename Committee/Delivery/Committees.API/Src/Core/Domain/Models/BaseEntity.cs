namespace Committees.Domain.Models
{
    public class BaseEntity<TKey>
    {
        public TKey Id { set; get; }
        public State State { set; get; }
        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}

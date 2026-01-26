namespace Committees.Infrastructure.ModelsConfigurations
{
	public class MeetingConfig:IEntityTypeConfiguration<Meeting>
	{
		public void Configure(EntityTypeBuilder<Meeting> builder)
		{
			builder.HasMany(a => a.MeetingAttachments)
					.WithOne(a => a.Meeting)
					.HasForeignKey(a => a.MeetingId);

			builder.HasMany(a => a.InternalMemberMeetings)
					.WithOne(a => a.Meeting)
					.HasForeignKey(a => a.MeetingId);
		}
	}
}

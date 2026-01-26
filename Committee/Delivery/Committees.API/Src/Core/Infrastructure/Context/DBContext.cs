namespace Committees.Infrastructure.Context
{
    public class DBContext : DbContext
    {

        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {
        }
        public DbSet<Committee> Committees { get; set; }
        public DbSet<LKProceedingAcceptance> LKProceedingAcceptances { get; set; }
        public DbSet<LKCommitteeTime> LKCommitteeTimes { get; set; }
        public DbSet<CommitteeAttachment> CommitteeAttachments { get; set; }
        public DbSet<ExternalMember> ExternalMembers { get; set; }
        public DbSet<InternalMember> InternalMembers { get; set; }
        public DbSet<Meeting> Meetings { get; set; }
        public DbSet<MeetingAttachment> MeetingAttachments { get; set; }
		public DbSet<Output> Outputs { get; set; }
		public DbSet<OutputAttachment> OutputAttachments { get; set; }
		public DbSet<OutputType> OutputTypes { get; set; }
		public DbSet<Permission> Permissions { get; set; }
		public DbSet<Proceeding> Proceedings { get; set; }
		public DbSet<ProceedingAttachment> ProceedingAttachments { get; set; }
		public DbSet<Target> Targets { get; set; }
		public DbSet<WorkRule> WorkRules { get; set; }
		public DbSet<InternalMemberMeeting> InternalMemberMeetings { get; set; }
		public DbSet<ExternalMemberMeeting> ExternalMemberMeetings { get; set; }
		public DbSet<InternalMemberProceeding> InternalMemberProceedings { get; set; }
		public DbSet<CommitteeInternalMember> CommitteeInternalMembers { get; set; }
		public DbSet<ExternalMemberProceeding> ExternalMemberProceeding { get; set; }
		public DbSet<MeetingProceeding> MeetingProceedings { get; set; }
		public DbSet<MeetingOutput> MeetingOutputs { get; set; }



        public bool AllMigrationsApplied()
        {
            var applied = this.GetService<IHistoryRepository>()
                .GetAppliedMigrations()
                .Select(m => m.MigrationId);

            var total = this.GetService<IMigrationsAssembly>()
                .Migrations
                .Select(m => m.Key);

            return !total.Except(applied).Any();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LKCommitteeTime>()
            .Property(x => x.Id)
            .UseIdentityColumn(seed: 0, increment: 1);


            modelBuilder.Entity<LKProceedingAcceptance>()
            .Property(x => x.Id)
            .UseIdentityColumn(seed: 0, increment: 1);


            base.OnModelCreating(modelBuilder);
        }
        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }
        public void Migrate()
        {
            this.Database.Migrate();
        }
    }
}
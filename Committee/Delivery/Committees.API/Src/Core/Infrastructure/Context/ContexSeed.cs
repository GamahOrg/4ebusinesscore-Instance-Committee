using Committees.Domain.Models;
using Committees.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace Committees.Infrastructure.Context
{
    public class ContexSeed
    {
        private static DBContext _dbContext;
        private static IServiceProvider _serviceProvider;
        //private readonly Permission<Permission> _userManager;
        private static IConfiguration _configuration;

        public static void SeedAll(DBContext context, IConfiguration configuration )
        {
            _dbContext = context;
            _configuration = configuration;

            // List all your entities and corresponding JSON files here
            SeedEntityLK<Permission>("Permissions.json", _dbContext.Permissions);
            SeedEntityLK<LKCommitteeTime>("LKCommitteeTime.json", _dbContext.LKCommitteeTimes);
            SeedEntityLK<OutputType>("OutputTypes.json", _dbContext.OutputTypes);
            SeedEntityLK<LKProceedingAcceptance>("LKProceedingAcceptance.json", _dbContext.LKProceedingAcceptances);

            if (bool.TryParse(_configuration["IsSeedData"], out var isSeedData) && isSeedData)
            {
                SeedEntity<Committee>("Committee.json", _dbContext.Committees);
                SeedEntity<InternalMember>("InternalMember.json", _dbContext.InternalMembers);
                SeedEntity<ExternalMember>("ExternalMember.json", _dbContext.ExternalMembers);
                SeedEntity<Meeting>("Meeting.json", _dbContext.Meetings);
                SeedEntity<Proceeding>("Proceeding.json", _dbContext.Proceedings);
                SeedEntity<Output>("Output.json", _dbContext.Outputs);
                SeedEntity<Target>("Target.json", _dbContext.Targets);
                SeedEntity<CommitteeInternalMember>("CommitteeInternal.json", _dbContext.CommitteeInternalMembers);
                SeedEntity<InternalMemberMeeting>("InternalMemberMeeting.json", _dbContext.InternalMemberMeetings);
                SeedEntity<ExternalMemberMeeting>("ExternalMemberMeeting.json", _dbContext.ExternalMemberMeetings);
                SeedEntity<InternalMemberProceeding>("InternalMemberProceeding.json", _dbContext.InternalMemberProceedings);
                SeedEntity<ExternalMemberProceeding>("ExternalMemberProceeding.json", _dbContext.ExternalMemberProceeding);
                SeedEntity<MeetingProceeding>("MeetingProceeding.json", _dbContext.MeetingProceedings);
                SeedEntity<MeetingOutput>("MeetingOutput.json", _dbContext.MeetingOutputs);
                SeedEntity<CommitteeAttachment>("CommitteesAttachments.json", _dbContext.CommitteeAttachments);
                SeedEntity<MeetingAttachment>("MeetingAttachments.json", _dbContext.MeetingAttachments);
                SeedEntity<ProceedingAttachment>("ProceedingAttachments.json", _dbContext.ProceedingAttachments);
                SeedEntity<OutputAttachment>("OutputAttachment.json", _dbContext.OutputAttachments);
                SeedEntity<WorkRule>("WorkRules.json", _dbContext.WorkRules);
            }
        }

        private static void SeedEntity<T>(string fileName, DbSet<T> dbSet) where T : class
        {
            string path = Path.Combine("SeedData", fileName);
            if (!File.Exists(path)) return;

            var json = File.ReadAllText(path);

            var entities = JsonConvert.DeserializeObject<List<T>>(json);
            if (entities == null || !entities.Any()) return;

            _dbContext.Database.OpenConnection();
            try
            {

                // Get existing IDs from DB as lowercase strings for safe comparison
                var existingData = dbSet
                    .AsNoTracking().ToList();

                if (!existingData.Any())
                {

                    // Filter only new items (skip existing ones)
                    var newEntities = entities
                        .ToList();

                    // Set CreatedOn if it exists
                    foreach (var entity in newEntities)
                    {
                        var createdOnProp = typeof(T).GetProperty("CreatedOn");
                        if (createdOnProp != null &&
                            (createdOnProp.PropertyType == typeof(DateTime) || createdOnProp.PropertyType == typeof(DateTime?)))
                        {
                            createdOnProp.SetValue(entity, DateTime.Now);
                        }
                    }

                    if (newEntities.Any())
                    {
                        var tableName = typeof(T).Name;
                        var idProsp = typeof(T).GetProperty("Id");

                        // Check if Id is int or nullable int
                        bool isIntId = idProsp != null &&
                                       (idProsp.PropertyType == typeof(int) || idProsp.PropertyType == typeof(int?));

                        if (isIntId)
                        {
                            _dbContext.Database.ExecuteSqlRaw($"SET IDENTITY_INSERT [{tableName}s] ON");
                        }
                        try
                        {
                            dbSet.AddRange(newEntities);
                            _dbContext.SaveChanges();
                        }
                        catch (Exception ex)
                        {

                            if (ex != null)
                            {
                                // skip if the error is about Wrong ForienKey
                                if (ex.Message.Contains("The INSERT statement conflicted with the FOREIGN KEY constraint"))
                                {
                                    return;
                                }
                            }
                        }
                        

                        if (isIntId)
                        {
                            _dbContext.Database.ExecuteSqlRaw($"SET IDENTITY_INSERT [{tableName}s] OFF");
                        }
                    }
                }

            }
            finally
            {
                _dbContext.Database.CloseConnection();
            }
        }

        private static void SeedEntityLK<T>(string fileName, DbSet<T> dbSet) where T : class
        {
            string path = Path.Combine("SeedData", fileName);
            if (!File.Exists(path)) return;

            var json = File.ReadAllText(path);

            var entities = JsonConvert.DeserializeObject<List<T>>(json);
            if (entities == null || !entities.Any()) return;

            _dbContext.Database.OpenConnection();
            try
            {
                var idProp = typeof(T).GetProperty("Id");
                if (idProp == null) return;

                // Get existing IDs from DB as lowercase strings for safe comparison
                var existingIds = dbSet
                    .AsNoTracking()
                    .Select(e => EF.Property<object>(e, "Id"))
                    .Where(id => id != null)
                    .Select(id => id.ToString().ToLower())
                    .ToHashSet();

                // Filter only new items (skip existing ones)
                var newEntities = entities
                    .Where(entity =>
                    {
                        var idValue = idProp.GetValue(entity);
                        return idValue != null && !existingIds.Contains(idValue.ToString().ToLower());
                    })
                    .ToList();

                // Set CreatedOn if it exists
                foreach (var entity in newEntities)
                {
                    var createdOnProp = typeof(T).GetProperty("CreatedOn");
                    if (createdOnProp != null &&
                        (createdOnProp.PropertyType == typeof(DateTime) || createdOnProp.PropertyType == typeof(DateTime?)))
                    {
                        createdOnProp.SetValue(entity, DateTime.Now);
                    }
                }

                if (newEntities.Any())
                {
                    var tableName = typeof(T).Name;
                    var idProsp = typeof(T).GetProperty("Id");

                    // Check if Id is int or nullable int
                    bool isIntId = idProsp != null &&
                                   (idProsp.PropertyType == typeof(int) || idProsp.PropertyType == typeof(int?));

                    //if (isIntId)
                    //{
                    //    _dbContext.Database.ExecuteSqlRaw($"SET IDENTITY_INSERT [{tableName}s] ON");
                    //}

                    dbSet.AddRange(newEntities);
                    _dbContext.SaveChanges();

                    //if (isIntId)
                    //{
                    //    _dbContext.Database.ExecuteSqlRaw($"SET IDENTITY_INSERT [{tableName}s] OFF");
                    //}
                }

            }
            finally
            {
                _dbContext.Database.CloseConnection();
            }
        }



    }

}

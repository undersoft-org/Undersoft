using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Undersoft.SSC.Service.Infrastructure.Stores.Mappings
{
    using Undersoft.SDK.Service.Data.Relation;
    using Undersoft.SDK.Service.Infrastructure.Store;
    using Undersoft.SSC.Entities.Account;
    using Undersoft.SSC.Entities.Schedule;

    public class ScheduleMappings : EntityTypeMapping<Schedule>
    {
        const string TABLE_NAME = "Schedules";

        public override void Configure(EntityTypeBuilder<Schedule> builder)
        {
            builder.ToTable(TABLE_NAME, DataStoreSchema.LocalSchema);

            modelBuilder
                .ApplyIdentifiers<Schedule>()
                .LinkSetToSet<Schedule, Setting>(ExpandSite.OnRight)
                .LinkSetToSet<Schedule, Detail>(ExpandSite.OnRight, true)
                .LinkOneToOne<Schedule, AccountLocation>(ExpandSite.OnRight)
                .LinkSetToSet<Schedule, Schedule>(
                    nameof(Schedule.RelatedTo),
                    nameof(Schedule.RelatedFrom),
                    ExpandSite.OnRight
                );
        }
    }
}

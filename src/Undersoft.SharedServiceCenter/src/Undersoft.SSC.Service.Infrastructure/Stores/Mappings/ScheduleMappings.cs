using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Undersoft.SSC.Service.Infrastructure.Stores.Mappings
{
    using Undersoft.SDK.Service.Data.Relation;
    using Undersoft.SDK.Service.Infrastructure.Store;
    using Undersoft.SSC.Entities.Accounts;
    using Undersoft.SSC.Entities.Resources;
    using Undersoft.SSC.Entities.Schedules;

    public class ScheduleMappings : EntityTypeMapping<Schedule>
    {
        const string TABLE_NAME = "Schedules";

        public override void Configure(EntityTypeBuilder<Schedule> builder)
        {
            builder.ToTable(TABLE_NAME, DataStoreSchema.LocalSchema);

            modelBuilder
                .ApplyIdentifiers<Schedule>()
                .RelateSetToSet<Schedule, ScheduleSetting>(ExpandSite.OnRight)
                .RelateOneToOne<Schedule, AccountLocation>(ExpandSite.OnRight)
                .RelateSetToSet<Schedule, ScheduleDetail>(ExpandSite.OnRight, true)
                .RelateSetToSet<Schedule, Schedule>(
                    nameof(Schedule.RelatedTo),
                    nameof(Schedule.RelatedFrom),
                    ExpandSite.OnRight
                )
                .RelateSetToSet<ScheduleDetail, ScheduleDetail>(
                    r => r.RelatedTo,
                    r => r.RelatedFrom,
                    ExpandSite.OnRight
                ).RelateSetToSet<ScheduleSetting, ScheduleSetting>(
                    r => r.RelatedTo,
                    r => r.RelatedFrom,
                    ExpandSite.OnRight
                );
            ;
        }
    }
}

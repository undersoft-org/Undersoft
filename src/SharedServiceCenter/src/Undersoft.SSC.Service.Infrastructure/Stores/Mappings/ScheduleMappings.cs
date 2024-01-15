using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Undersoft.SSC.Service.Infrastructure.Stores.Mappings;

using Undersoft.SDK.Service.Infrastructure.Store;
using Undersoft.SDK.Service.Infrastructure.Store.Relation;
using Undersoft.SSC.Entities.Members;
using Undersoft.SSC.Entities.Activities;
using Undersoft.SSC.Entities.Resources;
using Undersoft.SSC.Entities.Schedules;
using Undersoft.SSC.Entities.Schedules.Locations;

public class ScheduleMappings : EntityTypeMapping<Schedule>
{
    const string TABLE_NAME = "Schedules";

    public override void Configure(EntityTypeBuilder<Schedule> builder)
    {
        builder.ToTable(TABLE_NAME, DataStoreSchema.LocalSchema);

        modelBuilder
            .ApplyIdentifiers<Schedule>()
          .RelateSetToSet<Schedule, ScheduleSetting>(r => r.Schedules,
                    r => r.Settings, ExpandSite.OnRight)
                .RelateOneToOne<Schedule, ScheduleLocation>(r => r.Schedule,
                    r => r.Location, ExpandSite.OnRight)
                .RelateSetToSet<Schedule, ScheduleDetail>(r => r.Schedules,
                    r => r.Details, ExpandSite.OnRight, true)
            .RelateSetToSet<Schedule, Schedule>(
             r => r.RelatedFrom, r => r.RelatedTo,
                ExpandSite.OnRight
            )
            .RelateSetToRemoteSet<Schedule, Member>(
                r => r.MemberNode
            )
            .RelateSetToRemoteSet<Schedule, Activity>(
                r => r.ActivityNode
            )
            .RelateSetToRemoteSet<Schedule, Resource>(
                r => r.ResourceNode
            )
                         .RelateOneToSet<ScheduleDefault, Schedule>(
                    r => r.Default,
                    r => r.Schedules,
                    ExpandSite.OnLeft
                )
            .RelateSetToSet<ScheduleDetail, ScheduleDetail>(

                r => r.RelatedFrom, r => r.RelatedTo,
                ExpandSite.OnRight
            ).RelateSetToSet<ScheduleSetting, ScheduleSetting>(
                r => r.RelatedFrom, r => r.RelatedTo,
                ExpandSite.OnRight
            )
             .RelateOneToSet<ScheduleLocation, Endpoint>(
                    r => r.Location,
                    r => r.Endpoints,
                    ExpandSite.OnRight
                )
                .RelateOneToSet<ScheduleLocation, Position>(
                    r => r.Location,
                    r => r.Positions,
                    ExpandSite.OnRight
                );
        ;
    }
}

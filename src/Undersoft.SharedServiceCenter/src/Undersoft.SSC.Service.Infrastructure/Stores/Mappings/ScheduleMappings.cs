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
            .RelateSetToSet<Schedule, ScheduleSetting>(ExpandSite.OnRight)
            .RelateOneToOne<Schedule, MemberLocation>(ExpandSite.OnRight)
            .RelateSetToSet<Schedule, ScheduleDetail>(ExpandSite.OnRight, true)
            .RelateSetToSet<Schedule, Schedule>(
                nameof(Schedule.RelatedTo),
                nameof(Schedule.RelatedFrom),
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
            .RelateSetToSet<ScheduleDetail, ScheduleDetail>(
                r => r.RelatedTo,
                r => r.RelatedFrom,
                ExpandSite.OnRight
            ).RelateSetToSet<ScheduleSetting, ScheduleSetting>(
                r => r.RelatedTo,
                r => r.RelatedFrom,
                ExpandSite.OnRight
            )
            .RelateOneToSet<ScheduleLocation, Endpoint>(ExpandSite.OnRight)
            .RelateOneToSet<ScheduleLocation, Position>(ExpandSite.OnRight);
        ;
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Undersoft.SSC.Entities.Activities;

namespace Undersoft.SSC.Service.Infrastructure.Stores.Mappings
{
    using Undersoft.SDK.Service.Infrastructure.Store;
    using Undersoft.SDK.Service.Infrastructure.Store.Relation;
    using Undersoft.SSC.Entities.Members;
    using Undersoft.SSC.Entities.Activities.Locations;
    using Undersoft.SSC.Entities.Resources;
    using Undersoft.SSC.Entities.Schedules;

    public class ActivityMappings : EntityTypeMapping<Activity>
    {
        const string TABLE_NAME = "Activities";

        public override void Configure(EntityTypeBuilder<Activity> builder)
        {
            builder.ToTable(TABLE_NAME, DataStoreSchema.LocalSchema);

            modelBuilder
                .ApplyIdentifiers<Activity>()
                .RelateOneToSet<ActivityDefault, Activity>(r=> r.Default, r=> r.Activities, ExpandSite.OnLeft)
                .RelateOneToOne<Activity, ActivityLocation>(r => r.Activity, r => r.Location, ExpandSite.OnRight)
                .RelateSetToSet<Activity, ActivitySetting>(
                          l => l.Activities, r => r.Settings,
             
                    ExpandSite.OnRight
                )
                .RelateSetToRemoteSet<Activity, Member>(
                    r => r.MemberNode
                )
                .RelateSetToRemoteSet<Activity, Resource>(
                    r => r.ResourceNode
                )
                .RelateSetToRemoteSet<Activity, Schedule>(
                    r => r.ScheduleNode
                )
                .RelateSetToSet<Activity, ActivityDetail>(
                          l => l.Activities, r => r.Details,
           
                    ExpandSite.OnRight,
                    true
                )
                .RelateSetToSet<ActivityDetail, ActivityDetail>(
            
                    r => r.RelatedFrom, r => r.RelatedTo,
                    ExpandSite.OnRight
                )
                .RelateSetToSet<ActivitySetting, ActivitySetting>(

                    r => r.RelatedFrom, r => r.RelatedTo,
                    ExpandSite.OnRight
                )
                .RelateSetToSet<Activity, Activity>(
      
                    rm => rm.RelatedFrom,
                    nameof(ActivityDetail.Activities),
                                  rm => rm.RelatedTo,
                    nameof(ActivityDetail.Activities),
                    ExpandSite.OnRight
                )
                .RelateOneToSet<ActivityLocation, Endpoint>(ExpandSite.OnRight)
                .RelateOneToSet<ActivityLocation, Position>(ExpandSite.OnRight);
        }
    }
}

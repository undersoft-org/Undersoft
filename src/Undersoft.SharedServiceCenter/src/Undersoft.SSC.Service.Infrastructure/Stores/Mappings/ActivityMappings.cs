using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Undersoft.SSC.Service.Infrastructure.Stores.Mappings
{
    using Undersoft.SDK.Service.Data.Relation;
    using Undersoft.SDK.Service.Infrastructure.Store;
    using Undersoft.SSC.Entities.Accounts;
    using Undersoft.SSC.Entities.Activity;
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
                .RelateOneToSet<ActivityDefault, Activity>(ExpandSite.OnLeft)
                .RelateOneToOne<Activity, ActivityLocation>(ExpandSite.OnRight)
                .RelateSetToSet<Activity, ActivitySetting>(
                    r => r.Settings,
                    l => l.Activities,
                    ExpandSite.OnRight
                )
                .RelateSetToRemoteSet<Account, Activity>(
                    r => r.AccountsToActivities,
                    r => r.Accounts,
                    ExpandSite.OnRight
                )
                .RelateSetToRemoteSet<Activity, Resource>(
                    r => r.AccountsToResources,
                    r => r.Accounts,
                    ExpandSite.OnRight
                )
                .RelateSetToRemoteSet<Activity, Schedule>(
                    r => r.AccountsToSchedules,
                    r => r.Accounts,
                    ExpandSite.OnRight
                )
                .RelateSetToSet<Activity, ActivityDetail>(
                    r => r.Details,
                    l => l.Activities,
                    ExpandSite.OnRight,
                    true
                )
                .RelateSetToSet<ActivityDetail, ActivityDetail>(
                    r => r.RelatedTo,
                    r => r.RelatedFrom,
                    ExpandSite.OnRight
                )
                .RelateSetToSet<ActivitySetting, ActivitySetting>(
                    r => r.RelatedTo,
                    r => r.RelatedFrom,
                    ExpandSite.OnRight
                )
                .RelateSetToSet<Activity, Activity>(
                    rm => rm.RelatedTo,
                    nameof(ActivityDetail.Activities),
                    rm => rm.RelatedFrom,
                    nameof(ActivityDetail.Activities),
                    ExpandSite.OnRight
                );
        }
    }
}

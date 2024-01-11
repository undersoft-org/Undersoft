using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Undersoft.SSC.Service.Infrastructure.Stores.Mappings
{
    using Undersoft.SDK.Service.Data.Relation;
    using Undersoft.SDK.Service.Infrastructure.Store;
    using Undersoft.SSC.Entities.Account;
    using Undersoft.SSC.Entities.Activity;
    using Undersoft.SSC.Entities.Resource;
    using Undersoft.SSC.Entities.Schedule;

    public class ActivityMappings : EntityTypeMapping<Activity>
    {
        const string TABLE_NAME = "Activities";

        public override void Configure(EntityTypeBuilder<Activity> builder)
        {
            builder.ToTable(TABLE_NAME, DataStoreSchema.LocalSchema);

            modelBuilder
                .ApplyIdentifiers<Activity>()
                .LinkOneToOne<Activity, AccountLocation>(ExpandSite.OnRight)
                .LinkSetToSet<Activity, Account>(
                    nameof(Resource.Activities),
                    nameof(Resource.Activities),
                    nameof(Activity.Accounts),
                    nameof(Activity.Accounts),
                    ExpandSite.OnRight,
                    true
                )
                .LinkSetToSet<Activity, Resource>(
                    nameof(Resource.Activities),
                    nameof(Resource.Activities),
                    nameof(Activity.Resources),
                    nameof(Activity.Resources),
                    ExpandSite.OnRight,
                    true
                )
                .LinkSetToSet<Activity, Schedule>(
                    nameof(Schedule.Activities),
                    nameof(Schedule.Activities),
                    nameof(Activity.Schedules),
                    nameof(Activity.Schedules),
                    ExpandSite.OnRight
                )
                .LinkSetToSet<Activity, Setting>(
                    nameof(Setting.Activities),
                    nameof(Setting.Activities),
                    nameof(Activity.Settings),
                    nameof(Activity.Settings),
                    ExpandSite.OnRight
                )
                .LinkSetToSet<Activity, Detail>(
                    nameof(Detail.Activities),
                    nameof(Detail.Activities),
                    nameof(Activity.Details),
                    nameof(Activity.Details),
                    ExpandSite.OnRight,
                    true
                )
                .LinkSetToSet<Activity, Activity>(
                    nameof(Activity.RelatedTo),
                    nameof(Detail.Activities),
                    nameof(Activity.RelatedFrom),
                    nameof(Detail.Activities),
                    ExpandSite.OnRight
                );
        }
    }
}

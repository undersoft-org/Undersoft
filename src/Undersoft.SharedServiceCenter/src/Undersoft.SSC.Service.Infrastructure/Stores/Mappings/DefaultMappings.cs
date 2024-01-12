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

    public class DefaultMappings : EntityTypeMapping<Default>
    {
        const string TABLE_NAME = "Defaults";

        public override void Configure(EntityTypeBuilder<Default> builder)
        {
            builder.ToTable(TABLE_NAME, DataStoreSchema.LocalSchema);

            modelBuilder
                .RelateOneToSet<Default, Account>(ExpandSite.OnLeft)
                .RelateOneToSet<Default, Resource>(ExpandSite.OnLeft)
                .RelateOneToSet<Default, Schedule>(ExpandSite.OnLeft)
                .RelateOneToSet<Default, Setting>(ExpandSite.OnRight)
                .RelateOneToSet<Default, Detail>(ExpandSite.OnRight)
                .RelateOneToSet<Default, Activity>(
                    nameof(Activity.Default),
                    nameof(Activity.Default),
                    nameof(Default.Activities),
                    nameof(Default.Activities),
                    ExpandSite.OnLeft
                );
        }
    }
}

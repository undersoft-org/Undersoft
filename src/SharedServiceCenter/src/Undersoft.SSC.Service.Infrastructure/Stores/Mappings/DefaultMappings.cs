using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Undersoft.SSC.Service.Infrastructure.Stores.Mappings
{
    using SDK.Service.Infrastructure.Store;
    using Undersoft.SDK.Service.Infrastructure.Store.Relation;
    using Undersoft.SSC.Domain.Entities;
    using Undersoft.SSC.Domain.Entities.Locations;

    public class DefaultMappings : EntityTypeMapping<Default>
    {
        const string TABLE_NAME = "Defaults";

        public override void Configure(EntityTypeBuilder<Default> builder)
        {
            builder.ToTable(TABLE_NAME, DataStoreSchema.LocalSchema);

            modelBuilder
                .RelateOneToSet<Default, Detail>(
                    r => r.Default,
                    r => r.Details,
                    ExpandSite.OnRight
                )
                .RelateOneToSet<Default, Setting>(
                    r => r.Default,
                    r => r.Settings,
                    ExpandSite.OnRight
                );
        }
    }
}

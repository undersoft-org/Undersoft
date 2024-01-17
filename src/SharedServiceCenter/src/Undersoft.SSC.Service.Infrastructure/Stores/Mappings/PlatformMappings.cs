using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Undersoft.SSC.Service.Infrastructure.Stores.Mappings
{
    using SDK.Service.Infrastructure.Store;
    using Undersoft.SDK.Service.Infrastructure.Store.Relation;
    using Undersoft.SSC.Domain.Entities;
    using Undersoft.SSC.Domain.Entities.Locations;

    public class PlatformMappings : EntityTypeMapping<Platform>
    {
        const string TABLE_NAME = "Platforms";

        public override void Configure(EntityTypeBuilder<Platform> builder)
        {
            builder.ToTable(TABLE_NAME, DataStoreSchema.LocalSchema);

            modelBuilder
                .ApplyIdentifiers<Platform>()
                .RelateSetToSet<Platform, Member>(
                    r => r.Platforms,
                    r => r.Members,
                    ExpandSite.OnRight
                )
                .RelateSetToSet<Platform, Setting>(
                    r => r.Platforms,
                    r => r.Settings,
                    ExpandSite.OnRight
                )
                .RelateOneToOne<Platform, Location>(
                    r => r.Platform,
                    r => r.Location,
                    ExpandSite.OnRight
                )
                .RelateSetToSet<Platform, Detail>(
                    r => r.Platforms,
                    r => r.Details,
                    ExpandSite.OnRight
                )
                .RelateOneToSet<Default, Platform>(
                    r => r.Default,
                    r => r.Platforms,
                    ExpandSite.OnLeft
                )
                .RelateSetToSet<Platform, Platform>(
                    r => r.RelatedFrom,
                    nameof(Platform),
                    r => r.RelatedTo,
                    nameof(Platform),
                    ExpandSite.OnRight
                );
        }
    }
}

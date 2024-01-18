using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Undersoft.SSC.Service.Infrastructure.Stores.Mappings.Locations
{
    using SDK.Service.Infrastructure.Store;
    using Undersoft.SDK.Service.Infrastructure.Store.Relation;
    using Undersoft.SSC.Domain.Entities;
    using Undersoft.SSC.Domain.Entities.Locations;

    public class LocationMappings : EntityTypeMapping<Location>
    {
        const string TABLE_NAME = "Locations";

        public override void Configure(EntityTypeBuilder<Location> builder)
        {
            builder.ToTable(TABLE_NAME, DataStoreSchema.LocalSchema);

            modelBuilder
                .RelateOneToSet<Location, Endpoint>(
                    r => r.Location,
                    r => r.Endpoints,
                    ExpandSite.OnRight
                )
                .RelateOneToSet<Location, Position>(
                    r => r.Location,
                    r => r.Positions,
                    ExpandSite.OnRight
                );
        }
    }
}

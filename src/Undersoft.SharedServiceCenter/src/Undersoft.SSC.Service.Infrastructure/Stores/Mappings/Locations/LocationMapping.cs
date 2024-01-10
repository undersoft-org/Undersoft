using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Undersoft.SSC.Service.Infrastructure.Stores.Mappings.Locations;

using Undersoft.SDK.Service.Data.Relation;
using Undersoft.SDK.Service.Infrastructure.Store;
using Undersoft.SSC.Entities;
using Undersoft.SSC.Entities.Locations;

public class LocationMapping : EntityTypeMapping<Location>
{
    private const string TABLE_NAME = "Locations";

    public override void Configure(EntityTypeBuilder<Location> builder)
    {
        builder.ToTable(TABLE_NAME, DataStoreSchema.LocalSchema);

        modelBuilder
            .LinkOneToSet<Location, Endpoint>(ExpandSite.OnRight)
            .LinkOneToSet<Location, Address>(
                nameof(Address.Location),
                nameof(Location.Addresses),
                ExpandSite.OnRight
            );
    }
}

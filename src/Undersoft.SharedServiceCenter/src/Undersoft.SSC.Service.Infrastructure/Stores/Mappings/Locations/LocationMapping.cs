using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Undersoft.SSC.Service.Infrastructure.Stores.Mappings.Locations;

using Undersoft.SDK.Service.Data.Relation;
using Undersoft.SDK.Service.Infrastructure.Store;
using Undersoft.SSC.Entities.Accounts;
using Undersoft.SSC.Entities.Locations;

public class LocationMapping : EntityTypeMapping<AccountLocation>
{
    private const string TABLE_NAME = "Locations";

    public override void Configure(EntityTypeBuilder<AccountLocation> builder)
    {
        builder.ToTable(TABLE_NAME, DataStoreSchema.LocalSchema);

        modelBuilder
            .RelateOneToSet<AccountLocation, Endpoint>(ExpandSite.OnRight)
            .RelateOneToSet<AccountLocation, Address>(
                nameof(Address.Location),
                nameof(AccountLocation.Addresses),
                ExpandSite.OnRight
            );
    }
}

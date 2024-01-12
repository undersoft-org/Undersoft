using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Undersoft.SSC.Service.Infrastructure.Stores.Mappings.Locations;

using Undersoft.SDK.Service.Data.Relation;
using Undersoft.SDK.Service.Infrastructure.Store;
using Undersoft.SSC.Entities.Locations;

public class CountryStateMapping : EntityTypeMapping<CountryState>
{
    private const string TABLE_NAME = "CountryStates";

    public override void Configure(EntityTypeBuilder<CountryState> builder)
    {
        builder.ToTable(TABLE_NAME, DataStoreSchema.LocalSchema);

        modelBuilder.RelateOneToSet<Country, CountryState>(
            nameof(CountryState.Country),
            nameof(Country.CountryStates), ExpandSite.OnRight);

        modelBuilder.RelateOneToSet<CountryState, Address>(
            nameof(Address.CountryState),
            nameof(CountryState.Addresses), ExpandSite.OnLeft);
    }
}
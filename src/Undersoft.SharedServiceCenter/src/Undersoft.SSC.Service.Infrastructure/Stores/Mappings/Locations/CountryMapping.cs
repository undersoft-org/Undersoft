using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Undersoft.SSC.Service.Infrastructure.Stores.Mappings.Locations;

using Undersoft.SDK.Service.Data.Relation;
using Undersoft.SDK.Service.Infrastructure.Store;
using Undersoft.SSC.Entities.Locations;

public class CountryMapping : EntityTypeMapping<Country>
{
    private const string TABLE_NAME = "Countries";

    public override void Configure(EntityTypeBuilder<Country> builder)
    {
        builder.ToTable(TABLE_NAME, DataStoreSchema.LocalSchema);

        modelBuilder.RelateOneToSet<Currency, Country>(
        nameof(Country.Currency),
        nameof(Currency.Countries), ExpandSite.OnLeft);

        modelBuilder.RelateOneToSet<Country, Address>(
          nameof(Address.Country),
          nameof(Country.Addresses), ExpandSite.OnLeft);
    }
}
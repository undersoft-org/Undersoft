﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Undersoft.SSC.Infrastructure.Persistance.Stores.Mappings.Locations;


using Undersoft.SSC.Domain.Entities.Locations;

public class CountryStateMapping : EntityTypeMapping<CountryState>
{
    private const string TABLE_NAME = "CountryStates";

    public override void Configure(EntityTypeBuilder<CountryState> builder)
    {
        builder.ToTable(TABLE_NAME, DataStoreSchema.LocalSchema);

        modelBuilder.LinkOneToSet<Country, CountryState>(
            nameof(CountryState.Country),
            nameof(Country.CountryStates), ExpandSite.OnRight);

        modelBuilder.LinkOneToSet<CountryState, Address>(
            nameof(Address.CountryState),
            nameof(CountryState.Addresses), ExpandSite.OnLeft);
    }
}
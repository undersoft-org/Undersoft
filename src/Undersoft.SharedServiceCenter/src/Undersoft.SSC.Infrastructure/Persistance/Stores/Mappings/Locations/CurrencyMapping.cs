using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Undersoft.SSC.Infrastructure.Persistance.Stores.Mappings.Locations;


using Undersoft.SSC.Domain.Entities.Locations;

public class CurrencyMapping : EntityTypeMapping<Currency>
{
    const string TABLE_NAME = "Currencies";

    public override void Configure(EntityTypeBuilder<Currency> builder)
    {
        builder.ToTable(TABLE_NAME, DataStoreSchema.LocalSchema);
    }
}

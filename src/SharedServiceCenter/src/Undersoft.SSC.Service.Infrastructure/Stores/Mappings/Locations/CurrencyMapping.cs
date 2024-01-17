using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Undersoft.SSC.Service.Infrastructure.Stores.Mappings.Locations;

using Undersoft.SDK.Service.Infrastructure.Store;
using Undersoft.SSC.Domain.Entities.Locations;

public class CurrencyMappings : EntityTypeMapping<Currency>
{
    const string TABLE_NAME = "Currencies";

    public override void Configure(EntityTypeBuilder<Currency> builder)
    {
        builder.ToTable(TABLE_NAME, DataStoreSchema.LocalSchema);
    }
}

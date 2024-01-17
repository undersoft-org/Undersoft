using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Undersoft.SSC.Service.Infrastructure.Stores.Mappings.Locations;

using Undersoft.SDK.Service.Infrastructure.Store;
using Undersoft.SSC.Domain.Entities.Locations;

public class PositionMappings : EntityTypeMapping<Position>
{
    private const string TABLE_NAME = "Coordinates";

    public override void Configure(EntityTypeBuilder<Position> builder)
    {
        builder.ToTable(TABLE_NAME, DataStoreSchema.LocalSchema);
    }
}
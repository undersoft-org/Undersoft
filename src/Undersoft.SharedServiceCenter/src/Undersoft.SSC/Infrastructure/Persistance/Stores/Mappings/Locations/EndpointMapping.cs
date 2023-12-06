using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Undersoft.SSC.Infrastructure.Persistance.Stores.Mappings.Locations;


using Undersoft.SSC.Domain.Entities.Locations;

public class EndpointMapping : EntityTypeMapping<Endpoint>
{
    private const string TABLE_NAME = "Endpoints";

    public override void Configure(EntityTypeBuilder<Endpoint> builder)
    {
        builder.ToTable(TABLE_NAME, DataStoreSchema.LocalSchema);
    }
}
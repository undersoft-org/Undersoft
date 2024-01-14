using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Undersoft.SSC.Service.Infrastructure.Stores.Mappings.Locations;

using Undersoft.SDK.Service.Infrastructure.Store;
using Undersoft.SSC.Entities.Members.Locations;

public class EndpointMapping : EntityTypeMapping<Endpoint>
{
    private const string TABLE_NAME = "Endpoints";

    public override void Configure(EntityTypeBuilder<Endpoint> builder)
    {
        builder.ToTable(TABLE_NAME, DataStoreSchema.LocalSchema);
    }
}
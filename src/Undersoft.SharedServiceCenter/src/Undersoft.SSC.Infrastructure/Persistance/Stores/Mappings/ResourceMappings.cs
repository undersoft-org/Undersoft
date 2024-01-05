using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Undersoft.SSC.Infrastructure.Persistance.Stores.Mappings
{


    using Undersoft.SSC.Domain.Entities;

    public class ResourceMappings : EntityTypeMapping<Resource>
    {
        const string TABLE_NAME = "Resources";

        public override void Configure(EntityTypeBuilder<Resource> builder)
        {
            builder.ToTable(TABLE_NAME, DataStoreSchema.LocalSchema);

            modelBuilder
                .ApplyIdentifiers<Resource>()
                .LinkSetToSet<Resource, Schedule>(ExpandSite.OnRight)
                .LinkSetToSet<Resource, Setting>(ExpandSite.OnRight)
                .LinkSetToSet<Resource, Detail>(ExpandSite.OnRight, true)
                .LinkOneToOne<Resource, Location>(ExpandSite.OnRight)
                .LinkSetToSet<Resource, Resource>(
                    nameof(Resource.RelatedTo),
                    nameof(Resource.RelatedFrom),
                    ExpandSite.OnRight
                );
        }
    }
}

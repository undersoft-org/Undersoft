using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Undersoft.SSC.Service.Infrastructure.Stores.Mappings
{
    using Undersoft.SDK.Service.Data.Relation;
    using Undersoft.SDK.Service.Infrastructure.Store;
    using Undersoft.SSC.Entities.Account;
    using Undersoft.SSC.Entities.Resource;
    using Undersoft.SSC.Entities.Schedule;

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
                .LinkOneToOne<Resource, AccountLocation>(ExpandSite.OnRight)
                .LinkSetToSet<Resource, Resource>(
                    nameof(Resource.RelatedTo),
                    nameof(Resource.RelatedFrom),
                    ExpandSite.OnRight
                );
        }
    }
}

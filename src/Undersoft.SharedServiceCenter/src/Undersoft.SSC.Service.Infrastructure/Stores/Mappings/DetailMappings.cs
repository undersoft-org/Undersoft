using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Undersoft.SSC.Service.Infrastructure.Stores.Mappings
{
    using Undersoft.SDK.Service.Data.Relation;
    using Undersoft.SDK.Service.Infrastructure.Store;
    using Undersoft.SSC.Entities;

    public class DetailMappings : EntityTypeMapping<Detail>
    {
        const string TABLE_NAME = "Details";

        public override void Configure(EntityTypeBuilder<Detail> builder)
        {
            builder.ToTable(TABLE_NAME, DataStoreSchema.LocalSchema);

            modelBuilder
                .ApplyIdentifiers<Detail>()
                .LinkSetToSet<Detail, Detail>(
                    nameof(Detail.RelatedTo),
                    nameof(Detail.RelatedFrom),
                    ExpandSite.OnRight
                );
        }
    }
}

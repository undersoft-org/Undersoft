using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Undersoft.SSC.Service.Infrastructure.Stores.Mappings
{
    using SDK.Service.Infrastructure.Store;
    using Undersoft.SDK.Service.Infrastructure.Store.Relation;
    using Undersoft.SSC.Domain.Entities;

    public class DetailMappings : EntityTypeMapping<Detail>
    {
        const string TABLE_NAME = "Details";

        public override void Configure(EntityTypeBuilder<Detail> builder)
        {
            builder.ToTable(TABLE_NAME, DataStoreSchema.DomainSchema);

            modelBuilder
                .ApplyIdentifiers<Detail>()
                .RelateSetToSet<Detail, Detail>(
                    r => r.RelatedFrom,
                    nameof(Detail),
                    r => r.RelatedTo,
                    nameof(Detail),
                    ExpandSite.OnRight
                );
            ;
        }
    }
}

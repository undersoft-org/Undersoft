using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Undersoft.SSC.Service.Infrastructure.Stores.Mappings
{
    using SDK.Service.Infrastructure.Store;
    using Undersoft.SDK.Service.Infrastructure.Store.Relation;
    using Undersoft.SSC.Domain.Entities.Locations;
    using Undersoft.SSC.Domain.Entities;

    public class InfrastructureMappings : EntityTypeMapping<Infrastructure>
    {
        const string TABLE_NAME = "Infrastructures";

        public override void Configure(EntityTypeBuilder<Infrastructure> builder)
        {
            builder.ToTable(TABLE_NAME, DataStoreSchema.LocalSchema);

            modelBuilder
                .ApplyIdentifiers<Infrastructure>()
                .RelateSetToSet<Infrastructure, Member>(r => r.Infrastructures, r => r.Members)
                .RelateSetToSet<Infrastructure, Setting>(
                    r => r.Infrastructures,
                    r => r.Settings,
                    ExpandSite.OnRight
                )
                .RelateOneToOne<Infrastructure, Location>(
                    r => r.Infrastructure,
                    r => r.Location,
                    ExpandSite.OnRight
                )
                .RelateSetToSet<Infrastructure, Detail>(
                    r => r.Infrastructures,
                    r => r.Details,
                    ExpandSite.OnRight
                )
                .RelateOneToSet<Default, Infrastructure>(
                    r => r.Default,
                    r => r.Infrastructures,
                    ExpandSite.OnLeft
                )
                .RelateSetToSet<Infrastructure, Infrastructure>(
                    r => r.RelatedFrom,
                    nameof(Infrastructure),
                    r => r.RelatedTo,
                    nameof(Infrastructure),
                    ExpandSite.OnRight
                );
        }
    }
}

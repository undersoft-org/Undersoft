using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Undersoft.SSC.Service.Infrastructure.Stores.Mappings
{
    using SDK.Service.Infrastructure.Store;
    using Undersoft.SDK.Service.Infrastructure.Store.Relation;
    using Undersoft.SSC.Domain.Entities;
    using Undersoft.SSC.Domain.Entities.Locations;

    public class SettingMappings : EntityTypeMapping<Setting>
    {
        const string TABLE_NAME = "Settings";

        public override void Configure(EntityTypeBuilder<Setting> builder)
        {
            builder.ToTable(TABLE_NAME, DataStoreSchema.LocalSchema);

            modelBuilder
                .ApplyIdentifiers<Setting>()
                .RelateSetToSet<Setting, Setting>(
                    r => r.RelatedFrom,
                    r => r.RelatedTo,
                    ExpandSite.OnRight
                );
        }
    }
}

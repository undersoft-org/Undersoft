using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Undersoft.SSC.Service.Infrastructure.Stores.Mappings
{
    using Undersoft.SDK.Service.Data.Relation;
    using Undersoft.SDK.Service.Infrastructure.Store;
    using Undersoft.SSC.Entities;

    public class SettingMappings : EntityTypeMapping<Setting>
    {
        const string TABLE_NAME = "Settings";

        public override void Configure(EntityTypeBuilder<Setting> builder)
        {
            builder.ToTable(TABLE_NAME, DataStoreSchema.LocalSchema);

            modelBuilder
                .ApplyIdentifiers<Setting>()
                .LinkSetToSet<Setting, Setting>(
                    nameof(Setting.RelatedTo),
                    nameof(Setting.RelatedFrom),
                    ExpandSite.OnRight
                );
        }
    }
}

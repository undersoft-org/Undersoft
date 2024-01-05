using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Undersoft.SSC.Infrastructure.Persistance.Stores.Mappings
{
    using Undersoft.SSC.Domain.Entities;

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

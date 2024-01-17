using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Undersoft.SSC.Service.Infrastructure.Stores.Mappings
{
    using SDK.Service.Infrastructure.Store;
    using Undersoft.SDK.Service.Infrastructure.Store.Relation;
    using Undersoft.SSC.Domain.Entities.Locations;
    using Undersoft.SSC.Domain.Entities;

    public class EquipmentMappings : EntityTypeMapping<Equipment>
    {
        const string TABLE_NAME = "Equipment";

        public override void Configure(EntityTypeBuilder<Equipment> builder)
        {
            builder.ToTable(TABLE_NAME, DataStoreSchema.LocalSchema);

            modelBuilder
                .ApplyIdentifiers<Equipment>()
                .RelateSetToSet<Equipment, Member>(r => r.Equipment, r => r.Members)
                .RelateSetToSet<Equipment, Setting>(
                    r => r.Equipment,
                    r => r.Settings,
                    ExpandSite.OnRight
                )
                .RelateOneToOne<Equipment, Location>(
                    r => r.Equipment,
                    r => r.Location,
                    ExpandSite.OnRight
                )
                .RelateSetToSet<Equipment, Detail>(
                    r => r.Equipment,
                    r => r.Details,
                    ExpandSite.OnRight
                )
                .RelateOneToSet<Default, Equipment>(
                    r => r.Default,
                    r => r.Equipment,
                    ExpandSite.OnLeft
                )
                .RelateSetToSet<Equipment, Equipment>(
                    r => r.RelatedFrom,
                    nameof(Equipment),
                    r => r.RelatedTo,
                    nameof(Equipment),
                    ExpandSite.OnRight
                );
        }
    }
}

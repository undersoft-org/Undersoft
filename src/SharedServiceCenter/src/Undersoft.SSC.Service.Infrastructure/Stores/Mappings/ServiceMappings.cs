using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Undersoft.SSC.Service.Infrastructure.Stores.Mappings
{
    using SDK.Service.Infrastructure.Store;
    using Undersoft.SDK.Service.Infrastructure.Store.Relation;
    using Undersoft.SSC.Domain.Entities;
    using Undersoft.SSC.Domain.Entities.Locations;

    public class ServiceMappings : EntityTypeMapping<Service>
    {
        const string TABLE_NAME = "Services";

        public override void Configure(EntityTypeBuilder<Service> builder)
        {
            builder.ToTable(TABLE_NAME, DataStoreSchema.LocalSchema);

            modelBuilder
                .ApplyIdentifiers<Platform>()
                .RelateSetToSet<Service, Platform>(
                    r => r.Services,
                    r => r.Platforms,
                    ExpandSite.OnRight
                )
                .RelateSetToSet<Service, Equipment>(
                    r => r.Services,
                    r => r.Equipment,
                    ExpandSite.OnRight
                )
                .RelateSetToSet<Service, Member>(
                    r => r.Services,
                    r => r.Members,
                    ExpandSite.OnRight
                )
                .RelateSetToSet<Service, Setting>(
                    r => r.Services,
                    r => r.Settings,
                    ExpandSite.OnRight
                )
                .RelateOneToOne<Service, Location>(
                    r => r.Service,
                    r => r.Location,
                    ExpandSite.OnRight
                )
                .RelateSetToSet<Service, Detail>(
                    r => r.Services,
                    r => r.Details,
                    ExpandSite.OnRight
                )
                .RelateOneToSet<Default, Service>(
                    r => r.Default,
                    r => r.Services,
                    ExpandSite.OnLeft
                )
                .RelateSetToSet<Service, Service>(
                    r => r.RelatedFrom,
                    nameof(Service),
                    r => r.RelatedTo,
                    nameof(Service),
                    ExpandSite.OnRight
                );
            ;
        }
    }
}

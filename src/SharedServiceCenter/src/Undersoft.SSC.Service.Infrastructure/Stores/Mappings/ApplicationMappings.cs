using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Undersoft.SSC.Service.Infrastructure.Stores.Mappings
{
    using SDK.Service.Infrastructure.Store;
    using Undersoft.SDK.Service.Infrastructure.Store.Relation;
    using Undersoft.SSC.Domain.Entities.Locations;
    using Undersoft.SSC.Domain.Entities;

    public class ApplicationMappings : EntityTypeMapping<Application>
    {
        const string TABLE_NAME = "Applications";

        public override void Configure(EntityTypeBuilder<Application> builder)
        {
            builder.ToTable(TABLE_NAME, DataStoreSchema.LocalSchema);

            modelBuilder
                .ApplyIdentifiers<Platform>()
                .RelateSetToSet<Application, Service>(r => r.Applications, r => r.Services)
                .RelateSetToSet<Application, Member>(r => r.Applications, r => r.Members)
                .RelateSetToSet<Application, Setting>(
                    r => r.Applications,
                    r => r.Settings,
                    ExpandSite.OnRight
                )
                .RelateOneToOne<Application, Location>(
                    r => r.Application,
                    r => r.Location,
                    ExpandSite.OnRight
                )
                .RelateSetToSet<Application, Detail>(
                    r => r.Applications,
                    r => r.Details,
                    ExpandSite.OnRight
                )
                .RelateOneToSet<Default, Application>(
                    r => r.Default,
                    r => r.Applications,
                    ExpandSite.OnLeft
                )
                .RelateSetToSet<Application, Application>(
                    r => r.RelatedFrom,
                    nameof(Application),
                    r => r.RelatedTo,
                    nameof(Application),
                    ExpandSite.OnRight
                );
        }
    }
}

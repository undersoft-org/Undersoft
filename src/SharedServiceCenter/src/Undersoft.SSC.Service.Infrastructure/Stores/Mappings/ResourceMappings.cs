using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Undersoft.SSC.Service.Infrastructure.Stores.Mappings;

using Undersoft.SDK.Service.Infrastructure.Store;
using Undersoft.SDK.Service.Infrastructure.Store.Relation;
using Undersoft.SSC.Domain.Entities.Locations;
using Undersoft.SSC.Domain.Entities;

public class ResourceMappings : EntityTypeMapping<Resource>
{
    const string TABLE_NAME = "Resources";

    public override void Configure(EntityTypeBuilder<Resource> builder)
    {
        builder.ToTable(TABLE_NAME, DataStoreSchema.DomainSchema);

        modelBuilder
                 .ApplyIdentifiers<Resource>()
                 .RelateSetToSet<Resource, Schedule>(
                     r => r.Resources,
                     r => r.Schedules,
                     ExpandSite.OnRight
                 )
                 .RelateSetToSet<Resource, Setting>(
                     r => r.Resources,
                     r => r.Settings,
                     ExpandSite.OnRight
                 )
                 .RelateOneToOne<Resource, Location>(
                     r => r.Resource,
                     r => r.Location,
                     ExpandSite.OnRight
                 )
                 .RelateSetToSet<Resource, Detail>(
                     r => r.Resources,
                     r => r.Details,
                     ExpandSite.OnRight
                 )
                 .RelateOneToSet<Default, Resource>(
                     r => r.Default,
                     r => r.Resources,
                     ExpandSite.OnLeft
                 )
                 .RelateSetToSet<Resource, Resource>(
                     r => r.RelatedFrom,
                     nameof(Resource),
                     r => r.RelatedTo,
                     nameof(Resource),
                     ExpandSite.OnRight
                 );
    }
}
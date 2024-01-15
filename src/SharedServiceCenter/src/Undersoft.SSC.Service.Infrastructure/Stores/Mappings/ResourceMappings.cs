using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Undersoft.SSC.Service.Infrastructure.Stores.Mappings;

using Undersoft.SDK.Service.Infrastructure.Store;
using Undersoft.SDK.Service.Infrastructure.Store.Relation;
using Undersoft.SSC.Entities.Members;
using Undersoft.SSC.Entities.Activities;
using Undersoft.SSC.Entities.Resources;
using Undersoft.SSC.Entities.Resources.Locations;
using Undersoft.SSC.Entities.Schedules;

public class ResourceMappings : EntityTypeMapping<Resource>
{
    const string TABLE_NAME = "Resources";

    public override void Configure(EntityTypeBuilder<Resource> builder)
    {
        builder.ToTable(TABLE_NAME, DataStoreSchema.LocalSchema);

        modelBuilder
            .ApplyIdentifiers<Resource>()
            .RelateSetToSet<Resource, ResourceSetting>(r => r.Resources,
                r => r.Settings, ExpandSite.OnRight)
            .RelateOneToOne<Resource, ResourceLocation>(r => r.Resource,
                r => r.Location, ExpandSite.OnRight)
            .RelateSetToSet<Resource, ResourceDetail>(r => r.Resources,
                r => r.Details, ExpandSite.OnRight, true)
            .RelateSetToSet<Resource, Resource>(
                           r => r.RelatedFrom, r => r.RelatedTo,
                ExpandSite.OnRight
            )
            .RelateSetToRemoteSet<Resource, Member>(
                r => r.MemberNode
            )
            .RelateSetToRemoteSet<Resource, Activity>(
                r => r.ActivityNode
            )
            .RelateSetToRemoteSet<Resource, Schedule>(
                r => r.ScheduleNode
            )
            .RelateSetToSet<ResourceDetail, ResourceDetail>(

                r => r.RelatedFrom, r => r.RelatedTo,
                ExpandSite.OnRight
            )
            .RelateSetToSet<ResourceSetting, ResourceSetting>(

                r => r.RelatedFrom, r => r.RelatedTo,
                ExpandSite.OnRight
            )
                .RelateOneToSet<ResourceDefault, Resource>(
                r => r.Default,
                r => r.Resources,
                ExpandSite.OnLeft
            )
           .RelateOneToSet<ResourceLocation, Endpoint>(
                r => r.Location,
                r => r.Endpoints,
                ExpandSite.OnRight
            )
            .RelateOneToSet<ResourceLocation, Position>(
                r => r.Location,
                r => r.Positions,
                ExpandSite.OnRight
            );
    }
}
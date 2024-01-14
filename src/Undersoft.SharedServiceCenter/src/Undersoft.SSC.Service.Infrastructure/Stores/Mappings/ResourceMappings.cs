using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Undersoft.SSC.Service.Infrastructure.Stores.Mappings
{
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
                .RelateSetToSet<Resource, ResourceSetting>(ExpandSite.OnRight)
                .RelateOneToOne<Resource, MemberLocation>(ExpandSite.OnRight)
                .RelateSetToSet<Resource, ResourceDetail>(ExpandSite.OnRight, true)
                .RelateSetToSet<Resource, Resource>(
                    nameof(Resource.RelatedTo),
                    nameof(Resource.RelatedFrom),
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
                    r => r.RelatedTo,
                    r => r.RelatedFrom,
                    ExpandSite.OnRight
                )
                .RelateSetToSet<ResourceSetting, ResourceSetting>(
                    r => r.RelatedTo,
                    r => r.RelatedFrom,
                    ExpandSite.OnRight
                )
                .RelateOneToSet<ResourceLocation, Endpoint>(ExpandSite.OnRight)
                .RelateOneToSet<ResourceLocation, Position>(ExpandSite.OnRight);
        }
    }
}

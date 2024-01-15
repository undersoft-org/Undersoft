using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Undersoft.SSC.Service.Infrastructure.Stores.Mappings
{
    using SDK.Service.Infrastructure.Store;
    using SSC.Entities.Platforms;
    using Undersoft.SDK.Service.Infrastructure.Store.Relation;
    using Undersoft.SSC.Entities.Platforms.Locations;
    using Undersoft.SSC.Entities.Activities;
    using Undersoft.SSC.Entities.Resources;
    using Undersoft.SSC.Entities.Schedules;
    using Undersoft.SSC.Entities.Members;

    public class PlatformMappings : EntityTypeMapping<Platform>
    {
        const string TABLE_NAME = "Platforms";

        public override void Configure(EntityTypeBuilder<Platform> builder)
        {
            builder.ToTable(TABLE_NAME, DataStoreSchema.LocalSchema);

            modelBuilder
                .ApplyIdentifiers<Platform>()
                .RelateSetToRemoteSet<Platform, Member>(r => r.MemberNode)
                .RelateSetToRemoteSet<Platform, Activity>(r => r.ActivityNode)
                .RelateSetToRemoteSet<Platform, Resource>(r => r.ResourceNode)
                .RelateSetToRemoteSet<Platform, Schedule>(r => r.ScheduleNode)
                .RelateSetToSet<Platform, PlatformSetting>(
                    r => r.Platforms,
                    r => r.Settings,
                    ExpandSite.OnRight
                )
                .RelateOneToOne<Platform, PlatformLocation>(
                    r => r.Platform,
                    r => r.Location,
                    ExpandSite.OnRight
                )
                .RelateSetToSet<Platform, PlatformDetail>(
                    r => r.Platforms,
                    r => r.Details,
                    ExpandSite.OnRight
                )
                .RelateOneToSet<PlatformLocation, Endpoint>(
                    r => r.Location,
                    r => r.Endpoints,
                    ExpandSite.OnRight
                )
                .RelateOneToSet<PlatformLocation, Position>(
                    r => r.Location,
                    r => r.Positions,
                    ExpandSite.OnRight
                )
                .RelateOneToSet<PlatformDefault, Platform>(
                    r => r.Default,
                    r => r.Platforms,
                    ExpandSite.OnLeft
                )
                .RelateSetToSet<Platform, Platform>(
                    r => r.RelatedFrom,
                    r => r.RelatedTo,
                    ExpandSite.OnRight
                )
                .RelateSetToSet<PlatformSetting, PlatformSetting>(
                    r => r.RelatedFrom,
                    r => r.RelatedTo,
                    ExpandSite.OnRight
                )
                .RelateSetToSet<PlatformDetail, PlatformDetail>(
                    r => r.RelatedFrom,
                    r => r.RelatedTo,
                    ExpandSite.OnRight
                );
            ;
        }
    }
}

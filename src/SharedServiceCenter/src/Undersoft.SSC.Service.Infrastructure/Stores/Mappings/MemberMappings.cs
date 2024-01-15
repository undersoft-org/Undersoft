using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Undersoft.SSC.Service.Infrastructure.Stores.Mappings
{
    using SDK.Service.Infrastructure.Store;
    using SSC.Entities.Members;
    using Undersoft.SDK.Service.Infrastructure.Store.Relation;
    using Undersoft.SSC.Entities.Members.Locations;
    using Undersoft.SSC.Entities.Activities;
    using Undersoft.SSC.Entities.Resources;
    using Undersoft.SSC.Entities.Schedules;

    public class MemberMappings : EntityTypeMapping<Member>
    {
        const string TABLE_NAME = "Members";

        public override void Configure(EntityTypeBuilder<Member> builder)
        {
            builder.ToTable(TABLE_NAME, DataStoreSchema.LocalSchema);

            modelBuilder
                .ApplyIdentifiers<Member>()
                .RelateSetToRemoteSet<Member, Activity>(r => r.ActivityNode)
                .RelateSetToRemoteSet<Member, Resource>(r => r.ResourceNode)
                .RelateSetToRemoteSet<Member, Schedule>(r => r.ScheduleNode)
                .RelateSetToSet<Member, MemberSetting>(
                    r => r.Members,
                    r => r.Settings,
                    ExpandSite.OnRight
                )
                .RelateOneToOne<Member, MemberLocation>(
                    r => r.Member,
                    r => r.Location,
                    ExpandSite.OnRight
                )
                .RelateSetToSet<Member, MemberDetail>(
                    r => r.Members,
                    r => r.Details,
                    ExpandSite.OnRight
                )
                .RelateOneToSet<MemberLocation, Endpoint>(
                    r => r.Location,
                    r => r.Endpoints,
                    ExpandSite.OnRight
                )
                .RelateOneToSet<MemberLocation, Position>(
                    r => r.Location,
                    r => r.Positions,
                    ExpandSite.OnRight
                )
                .RelateOneToSet<MemberLocation, Address>(
                    r => r.Location,
                    r => r.Addresses,
                    ExpandSite.OnRight
                )
                .RelateOneToSet<MemberDefault, Member>(
                    r => r.Default,
                    r => r.Members,
                    ExpandSite.OnLeft
                )
                .RelateSetToSet<Member, Member>(
                    r => r.RelatedFrom,
                    r => r.RelatedTo,
                    ExpandSite.OnRight
                )
                .RelateSetToSet<MemberSetting, MemberSetting>(
                    r => r.RelatedFrom,
                    r => r.RelatedTo,
                    ExpandSite.OnRight
                )
                .RelateSetToSet<MemberDetail, MemberDetail>(
                    r => r.RelatedFrom,
                    r => r.RelatedTo,
                    ExpandSite.OnRight
                );
            ;
        }
    }
}

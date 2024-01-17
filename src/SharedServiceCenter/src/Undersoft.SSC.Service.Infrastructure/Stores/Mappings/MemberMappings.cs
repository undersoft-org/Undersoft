using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Undersoft.SSC.Service.Infrastructure.Stores.Mappings
{
    using SDK.Service.Infrastructure.Store;
    using Undersoft.SDK.Service.Infrastructure.Store.Relation;
    using Undersoft.SSC.Domain.Entities;
    using Undersoft.SSC.Domain.Entities.Locations;

    public class MemberMappings : EntityTypeMapping<Member>
    {
        const string TABLE_NAME = "Members";

        public override void Configure(EntityTypeBuilder<Member> builder)
        {
            builder.ToTable(TABLE_NAME, DataStoreSchema.LocalSchema);

            modelBuilder
                .ApplyIdentifiers<Member>()
                .RelateSetToSet<Member, Activity>(
                    r => r.Members,
                    r => r.Activities
                )
                .RelateSetToSet<Member, Resource>(
                    r => r.Members,
                    r => r.Resources
                )
                .RelateSetToSet<Member, Schedule>(
                    r => r.Members,
                    r => r.Schedules
                )
                .RelateSetToSet<Member, Setting>(
                    r => r.Members,
                    r => r.Settings,
                    ExpandSite.OnRight
                )
                .RelateOneToOne<Member, Location>(
                    r => r.Member,
                    r => r.Location,
                    ExpandSite.OnRight
                )
                .RelateSetToSet<Member, Detail>(
                    r => r.Members,
                    r => r.Details,
                    ExpandSite.OnRight
                )
                .RelateOneToSet<Default, Member>(
                    r => r.Default,
                    r => r.Members,
                    ExpandSite.OnLeft
                )
                .RelateSetToSet<Member, Member>(
                    r => r.RelatedFrom,
                    nameof(Member),
                    r => r.RelatedTo,
                    nameof(Member),
                    ExpandSite.OnRight
                );
            ;
        }
    }
}

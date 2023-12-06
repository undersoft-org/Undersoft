using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Undersoft.SSC.Infrastructure.Persistance.Stores.Mappings
{
    using Undersoft.SSC.Domain.Entities;

    public class ScheduleMappings : EntityTypeMapping<Schedule>
    {
        const string TABLE_NAME = "Schedules";

        public override void Configure(EntityTypeBuilder<Schedule> builder)
        {
            builder.ToTable(TABLE_NAME, DataStoreSchema.LocalSchema);

            modelBuilder
                .ApplyIdentifiers<Schedule>()
                .LinkSetToSet<Schedule, Setting>(ExpandSite.OnRight)
                .LinkSetToSet<Schedule, Detail>(ExpandSite.OnRight, true)
                .LinkOneToOne<Schedule, Location>(ExpandSite.OnRight)
                .LinkSetToSet<Schedule, Schedule>(
                    nameof(Schedule.RelatedTo),
                    nameof(Schedule.RelatedFrom),
                    ExpandSite.OnRight
                );
        }
    }
}

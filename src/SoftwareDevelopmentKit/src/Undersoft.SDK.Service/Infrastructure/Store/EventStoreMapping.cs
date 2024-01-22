using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Undersoft.SDK.Service.Infrastructure.Store;

using Undersoft.SDK.Service.Data.Event;

public class EventStoreMapping : EntityTypeMapping<Event>
{
    private const string TABLE_NAME = "Events";

    public override void Configure(EntityTypeBuilder<Event> builder)
    {
        builder.ToTable(TABLE_NAME, DataStoreSchema.DomainSchema);

        builder.Property(p => p.PublishTime)
            .HasColumnType("timestamp");
    }
}
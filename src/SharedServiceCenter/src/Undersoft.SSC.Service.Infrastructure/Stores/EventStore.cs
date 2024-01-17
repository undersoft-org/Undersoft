using Microsoft.EntityFrameworkCore;
using Undersoft.SDK.Service.Data.Event;
using Undersoft.SDK.Service.Infrastructure.Store;

namespace Undersoft.SSC.Service.Infrastructure.Stores
{
    public class EventStore : Store<IEventStore, EventStore>
    {
        public EventStore(DbContextOptions<EventStore> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyMapping(new EventStoreMapping());
            base.OnModelCreating(modelBuilder);
        }

        public virtual DbSet<Event>? Events { get; set; }
    }
}

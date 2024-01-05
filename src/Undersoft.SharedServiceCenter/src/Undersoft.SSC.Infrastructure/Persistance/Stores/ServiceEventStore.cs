using Microsoft.EntityFrameworkCore;
using Undersoft.SDK.Service.Data.Store;

namespace Undersoft.SSC.Infrastructure.Persistance.Stores
{
    public class ServiceEventStore : Store<IEventStore, ServiceEventStore>
    {
        public ServiceEventStore(DbContextOptions<ServiceEventStore> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyMapping(new EventStoreMapping());
            base.OnModelCreating(modelBuilder);
        }

        public virtual DbSet<Event>? Events { get; set; }
    }
}

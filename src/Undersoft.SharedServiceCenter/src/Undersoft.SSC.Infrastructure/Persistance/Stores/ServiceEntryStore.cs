using Microsoft.EntityFrameworkCore;

namespace Undersoft.SSC.Infrastructure.Persistance.Stores
{
    public class ServiceEntryStore : ServiceDataStore<IEntryStore, ServiceEntryStore>
    {
        public ServiceEntryStore(DbContextOptions<ServiceEntryStore> options) : base(options) { }
    }
}

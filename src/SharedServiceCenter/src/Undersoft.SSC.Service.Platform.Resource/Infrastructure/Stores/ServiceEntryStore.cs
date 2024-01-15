using Microsoft.EntityFrameworkCore;
using Undersoft.SDK.Service.Infrastructure.Store;

namespace Undersoft.SSC.Service.Platform.Resource.Infrastructure.Stores
{
    public class ServiceEntryStore : ServiceDataStore<IEntryStore, ServiceEntryStore>
    {
        public ServiceEntryStore(DbContextOptions<ServiceEntryStore> options) : base(options) { }
    }
}

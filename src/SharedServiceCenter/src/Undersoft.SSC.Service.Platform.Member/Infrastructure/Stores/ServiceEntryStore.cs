using Microsoft.EntityFrameworkCore;
using Undersoft.SDK.Service.Infrastructure.Store;

namespace Undersoft.SSC.Service.Platform.Member.Infrastructure.Stores
{
    public class ServiceEntryStore : ServiceDataStore<IEntryStore, ServiceEntryStore>
    {
        public ServiceEntryStore(DbContextOptions<ServiceEntryStore> options) : base(options) { }
    }
}

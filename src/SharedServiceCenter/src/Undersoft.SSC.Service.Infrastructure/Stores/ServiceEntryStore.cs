using Microsoft.EntityFrameworkCore;
using Undersoft.SDK.Service.Infrastructure.Store;

namespace Undersoft.SSC.Service.Infrastructure.Stores
{
    public class ServiceEntryStore : Store<IEntryStore, ServiceEntryStore>
    {
        public ServiceEntryStore(DbContextOptions<ServiceEntryStore> options) : base(options) { }
    }
}

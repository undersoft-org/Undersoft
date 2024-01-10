using Microsoft.EntityFrameworkCore;
using Undersoft.SDK.Service.Server.Account.Identity;
using Undersoft.SDK.Service.Infrastructure.Store;

namespace Undersoft.SSC.Service.Infrastructure.Stores
{
    public class ServiceIdentityStore : IdentityStore<IIdentityStore, ServiceIdentityStore>
    {
        public ServiceIdentityStore(DbContextOptions<ServiceIdentityStore> options) : base(options)
        {
        }
    }
}

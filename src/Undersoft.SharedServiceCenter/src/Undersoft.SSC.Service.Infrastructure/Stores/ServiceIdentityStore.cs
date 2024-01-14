using Microsoft.EntityFrameworkCore;
using Undersoft.SDK.Service.Infrastructure.Store;
using Undersoft.SDK.Service.Application.Member;

namespace Undersoft.SSC.Service.Infrastructure.Stores
{
    public class ServiceIdentityStore : IdentityStore<IIdentityStore, ServiceIdentityStore>
    {
        public ServiceIdentityStore(DbContextOptions<ServiceIdentityStore> options) : base(options)
        {
        }
    }
}

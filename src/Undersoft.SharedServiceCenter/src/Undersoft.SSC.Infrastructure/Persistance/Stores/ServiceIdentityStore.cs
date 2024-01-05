using Microsoft.EntityFrameworkCore;
using Undersoft.SDK.Service.Application.Account.Identity;

namespace Undersoft.SSC.Infrastructure.Persistance.Stores
{
    public class ServiceIdentityStore : IdentityStore<IIdentityStore, ServiceIdentityStore>
    {
        public ServiceIdentityStore(DbContextOptions<ServiceIdentityStore> options) : base(options)
        {
        }
    }
}

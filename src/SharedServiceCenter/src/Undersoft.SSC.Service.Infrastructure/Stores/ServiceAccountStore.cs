using Microsoft.EntityFrameworkCore;
using Undersoft.SDK.Service.Application.Account;

namespace Undersoft.SSC.Service.Infrastructure.Stores
{
    public class ServiceAccountStore : AccountStore<IIdentityStore, ServiceAccountStore>
    {
        public ServiceAccountStore(DbContextOptions<ServiceAccountStore> options) : base(options)
        {
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Undersoft.SDK.Service.Server.Account;
using Undersoft.SDK.Service.Infrastructure.Store;

namespace Undersoft.SSC.Service.Infrastructure.Stores
{
    public class AccountStore : AccountStore<IAccountStore, AccountStore>
    {
        public AccountStore(DbContextOptions<AccountStore> options) : base(options)
        {
        }
    }
}

using Microsoft.AspNetCore.Authorization;
using Undersoft.SDK.Security.Identity;
using Undersoft.SDK.Service.Infrastructure.Store;
using Undersoft.SDK.Service.Application.Account;

namespace Undersoft.SSC.Service.Server.Controllers
{
    [AllowAnonymous]
    public class AccountController
        : AccountControllerBase<IDataStore, AccountAction, AccountService, Authorization>
    {
        public AccountController(IServicer servicer) : base(servicer) { }
    }
}

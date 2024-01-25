using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Undersoft.SDK.Security.Identity;
using Undersoft.SDK.Service;
using Undersoft.SDK.Service.Infrastructure.Store;
using Undersoft.SDK.Service.Server.Accounts;
using Undersoft.SDK.Service.Server.Controller.Crud;
using Undersoft.SDK.Service.Server.Controller.Open;
using Undersoft.SSC.Service.Application.Models;
using Account = Undersoft.SSC.Service.Contracts.Account;

namespace Undersoft.SSC.Service.Application.Server.Controllers
{
    [AllowAnonymous]
    [Route($"{StoreRoutes.ApiAuthRoute}/Account")]
    public class AccountsController
        : ApiDataRemoteController<long, IAccountStore, Account, Account, AccountService>
    {
        public AccountsController(IServicer servicer) : base(servicer) { }
    }

    [AllowAnonymous]
    public class AccountController
        : OpenDataRemoteController<long, IAccountStore, Account, Account, AccountService>
    {
        public AccountController(IServicer servicer) : base(servicer) { }
    }
}

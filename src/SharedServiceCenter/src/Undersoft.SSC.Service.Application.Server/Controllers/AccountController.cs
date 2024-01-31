using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Undersoft.SDK.Service;
using Undersoft.SDK.Service.Data.Store;
using Undersoft.SDK.Service.Server.Accounts;
using Undersoft.SDK.Service.Server.Controller.Crud;
using Undersoft.SDK.Service.Server.Controller.Open;

namespace Undersoft.SSC.Service.Application.Server.Controllers
{
    [AllowAnonymous]
    [Route($"{StoreRoutes.ApiDataRoute}/Account")]
    public class AccountsController
        : ApiDataRemoteController<long, IDataStore, Contracts.Account, Contracts.Account, AccountService>
    {
        public AccountsController(IServicer servicer) : base(servicer) { }
    }

    [AllowAnonymous]
    public class AccountController
        : OpenDataRemoteController<long, IDataStore, Contracts.Account, Contracts.Account, AccountService>
    {
        public AccountController(IServicer servicer) : base(servicer) { }
    }
}

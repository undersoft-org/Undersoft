using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Undersoft.SDK.Service;
using Undersoft.SDK.Service.Infrastructure.Store;
using Undersoft.SDK.Service.Server.Accounts;
using Undersoft.SDK.Service.Server.Controller.Crud;
using Undersoft.SDK.Service.Server.Controller.Open;
using Undersoft.SSC.Service.Application.Models;

namespace Undersoft.SSC.Service.Application.Server.Controllers
{
    [AllowAnonymous]
    [Route($"{StoreRoutes.ApiAuthRoute}/Account")]
    public class AccountsController
        : ApiServiceRemoteController<IDataStore, AccountService, Contracts.Account>
    {
        public AccountsController(IServicer servicer) : base(servicer) { }
    }


    [AllowAnonymous]
    public class AccountController
        : OpenDataRemoteController<long, IAccountStore, Contracts.Account, Models.Access, AccountService>
    {
        public AccountController(IServicer servicer) : base(servicer) { }
    }
}

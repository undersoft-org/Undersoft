using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Undersoft.SDK.Service.Server.Accounts;
using Undersoft.SDK.Service.Server.Controller.Crud;
using Undersoft.SDK.Service.Server.Controller.Open;
using Undersoft.SDK.Service.Server.Controller.Stream;

namespace Undersoft.SSC.Service.Server.Controllers
{
    [AllowAnonymous]
    [ApiVersion("OPEN")]
    public class AccountController
        : OpenDataController<long, IAccountStore, Account, Contracts.Account, AccountService>
    {
        public AccountController(IServicer ultimatr) : base(ultimatr) { }
    }

    [ApiVersion("REST")]
    [Route($"{StoreRoutes.ApiAuthRoute}/Account")]
    public class AccountsController
        : ApiDataController<long, IAccountStore, Account, Contracts.Account, AccountService>
    {
        public AccountsController(IServicer ultimatr) : base(ultimatr) { }
    }

    [ApiVersion("GRPC")]
    public class AccountStreamController
        : StreamEventController<long, IAccountStore, Account, Contracts.Account>
    {
        public AccountStreamController() : base() { }
    }
}

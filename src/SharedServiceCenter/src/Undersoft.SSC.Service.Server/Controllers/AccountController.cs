﻿using Microsoft.AspNetCore.Authorization;
using Undersoft.SDK.Service.Server.Controller.Crud;
using Undersoft.SDK.Service.Server.Controller.Open;
using Undersoft.SDK.Service.Server.Controller.Stream;
using Undersoft.SDK.Service.Infrastructure.Store;
using Microsoft.AspNetCore.OData.Routing.Attributes;
using Undersoft.SDK.Service.Server.Accounts;
using Microsoft.AspNetCore.Mvc;

namespace Undersoft.SSC.Service.Server.Controllers
{
    [AllowAnonymous]
    public class AccountController
        : OpenDataController<long, IAccountStore, Account, Contracts.Account>
    {
        public AccountController(IServicer ultimatr) : base(ultimatr) { }
    }
}

namespace Undersoft.SSC.Service.Server.Controllers
{
    [Route($"{StoreRoutes.CrudAuthRoute}/[controller]")]
    public class AccountsController
        : ApiDataController<long, IAccountStore, Account, Contracts.Account>
    {
        public AccountsController(IServicer ultimatr) : base(ultimatr) { }
    }
}

namespace Undersoft.SSC.Service.Server.Controllers
{
    public class AccountStreamController
        : StreamEventController<long, IAccountStore, Account, Contracts.Account>
    {
        public AccountStreamController() : base() { }
    }
}
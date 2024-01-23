﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Undersoft.SDK.Security.Identity;
using Undersoft.SDK.Service;
using Undersoft.SDK.Service.Infrastructure.Store;
using Undersoft.SDK.Service.Server.Accounts;
using Undersoft.SDK.Service.Server.Controller.Crud;
using Undersoft.SDK.Service.Server.Controller.Open;

namespace Undersoft.SSC.Service.Application.Server.Controllers
{
    [AllowAnonymous]
    [Route($"{StoreRoutes.ApiDataRoute}/Accounts/Authorization")]
    public class AccountsController
        : ApiServiceRemoteController<IDataStore, AccountService, Contracts.Account>
    {
        public AccountsController(IServicer servicer) : base(servicer) { }
    }
}

namespace Undersoft.SSC.Service.Application.Server.Controllers
{
    [AllowAnonymous]
    public class AuthorizationController
        : OpenServiceRemoteController<IDataStore, AccountService, Contracts.Account>
    {
        public AuthorizationController(IServicer servicer) : base(servicer) { }
    }
}

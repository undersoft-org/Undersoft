﻿using Microsoft.AspNetCore.Authorization;
using Undersoft.SDK.Service.Application.Controller.Crud;
using Undersoft.SSC.Domain.Entities.Enums;
using Undersoft.SSC.Web.Contracts;
using Undersoft.SSC.Web.ViewModels;

namespace Undersoft.SSC.Web.Application.Controllers
{
    using Microsoft.AspNetCore.OData.Routing.Attributes;
    using Undersoft.SDK.Service.Application.Controller.Open;

    [AllowAnonymous]
    [ODataRouteComponent(StoreRoutes.OpenDataStore)]
    public class ClientIdentifierController
        : OpenDataRemoteController<
            long,
            IDataStore,
            Identifier<AccountBase>,
            Identifier<Client>
        >
    {
        public ClientIdentifierController(IServicer ultimatr)
            : base(ultimatr, m => d => d.Object.Group == AccountGroup.Client) { }
    }
}

namespace Undersoft.SSC.Web.Application.Controllers
{
    [AllowAnonymous]
    public class ClientIdentifiersController
        : CrudDataRemoteController<
            long,
            IDataStore,
            Identifier<AccountBase>,
            Identifier<Client>
        >
    {
        public ClientIdentifiersController(IServicer ultimatr)
            : base(ultimatr, m => d => d.Object.Group == AccountGroup.Client) { }
    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.OData.Routing.Attributes;
using Undersoft.SDK.Service;
using Undersoft.SDK.Service.Data.Identifier;
using Undersoft.SDK.Service.Infrastructure.Store;
using Undersoft.SDK.Service.Server.Controller.Crud;
using Undersoft.SDK.Service.Server.Controller.Open;
using Undersoft.SSC.Entities.Account;
using Undersoft.SSC.Entities.Enums;
using Undersoft.SSC.Service.Application.Models;

namespace Undersoft.SSC.Service.Application.Server.Controllers
{

    [AllowAnonymous]
    [ODataRouteComponent(StoreRoutes.OpenDataRoute)]
    public class UserAccountIdentifierController
        : OpenDataRemoteController<long, IDataStore, Identifier<Account>, Identifier<UserAccount>>
    {
        public UserAccountIdentifierController(IServicer ultimatr)
            : base(ultimatr, m => d => d.Object.Group == AccountGroup.User) { }
    }
}

namespace Undersoft.SSC.Service.Application.Server.Controllers
{
    [AllowAnonymous]
    public class UserAccountIdentifiersController
        : CrudDataRemoteController<long, IDataStore, Identifier<Account>, Identifier<UserAccount>>
    {
        public UserAccountIdentifiersController(IServicer ultimatr)
            : base(ultimatr, m => d => d.Object.Group == AccountGroup.User) { }
    }
}

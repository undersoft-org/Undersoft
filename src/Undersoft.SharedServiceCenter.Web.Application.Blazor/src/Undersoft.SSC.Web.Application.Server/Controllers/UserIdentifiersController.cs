using Microsoft.AspNetCore.Authorization;
using Undersoft.SDK.Service.Application.Controller.Crud;
using Undersoft.SSC.Web.Contracts;
using Undersoft.SSC.Web.Application.ViewModels;
using Undersoft.SSC.Domain.Entities.Enums;
 using Microsoft.AspNetCore.OData.Routing.Attributes;
using Undersoft.SDK.Service;
using Undersoft.SDK.Service.Application.Controller.Open;
using Undersoft.SDK.Service.Data.Identifier;
using Undersoft.SDK.Service.Data.Store;


namespace Undersoft.SSC.Web.Application.Server.Controllers
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

namespace Undersoft.SSC.Web.Application.Server.Controllers
{
    [AllowAnonymous]
    public class UserAccountIdentifiersController
        : CrudDataRemoteController<long, IDataStore, Identifier<Account>, Identifier<UserAccount>>
    {
        public UserAccountIdentifiersController(IServicer ultimatr)
            : base(ultimatr, m => d => d.Object.Group == AccountGroup.User) { }
    }
}

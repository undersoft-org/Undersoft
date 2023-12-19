using Microsoft.AspNetCore.Authorization;
using Undersoft.SDK.Service.Application.Controller.Crud;
using Undersoft.SSC.Web.Contracts;
using Undersoft.SSC.Web.Application.ViewModels;
using Undersoft.SSC.Web.Enums;
 using Microsoft.AspNetCore.OData.Routing.Attributes;
using Undersoft.SDK.Service;
using Undersoft.SDK.Service.Application.Controller.Open;
using Undersoft.SDK.Service.Data.Identifier;
using Undersoft.SDK.Service.Data.Store;


namespace Undersoft.SSC.Web.Application.Server.Controllers
{

    [AllowAnonymous]
    [ODataRouteComponent(StoreRoutes.OpenDataStore)]
    public class UserIdentifierController
        : OpenDataRemoteController<long, IDataStore, Identifier<AccountBase>, Identifier<User>>
    {
        public UserIdentifierController(IServicer ultimatr)
            : base(ultimatr, m => d => d.Object.Group == AccountGroup.User) { }
    }
}

namespace Undersoft.SSC.Web.Application.Server.Controllers
{
    [AllowAnonymous]
    public class UserIdentifiersController
        : CrudDataRemoteController<long, IDataStore, Identifier<AccountBase>, Identifier<User>>
    {
        public UserIdentifiersController(IServicer ultimatr)
            : base(ultimatr, m => d => d.Object.Group == AccountGroup.User) { }
    }
}

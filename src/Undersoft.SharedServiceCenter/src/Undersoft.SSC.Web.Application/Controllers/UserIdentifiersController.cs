using Microsoft.AspNetCore.Authorization;
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
    public class UserIdentifierController
        : OpenDataRemoteController<long, IDataStore, Identifier<AccountBase>, Identifier<User>>
    {
        public UserIdentifierController(IServicer ultimatr)
            : base(ultimatr, m => d => d.Object.Group == AccountGroup.User) { }
    }
}

namespace Undersoft.SSC.Web.Application.Controllers
{
    [AllowAnonymous]
    public class UserIdentifiersController
        : CrudDataRemoteController<long, IDataStore, Identifier<AccountBase>, Identifier<User>>
    {
        public UserIdentifiersController(IServicer ultimatr)
            : base(ultimatr, m => d => d.Object.Group == AccountGroup.User) { }
    }
}

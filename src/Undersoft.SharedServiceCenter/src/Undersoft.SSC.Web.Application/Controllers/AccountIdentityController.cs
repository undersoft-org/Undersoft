using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Undersoft.SDK.Service.Application.Account.Identity;
using Undersoft.SDK.Service.Application.Controller.Crud;
using Undersoft.SDK.Service.Data;

namespace Undersoft.SSC.Web.Application.Controllers
{
    [AllowAnonymous]
    [Route($"{StoreRoutes.CrudDataStore}/[controller]")]
    public class AccountIdentityController
        : CrudDataActionRemoteController<IDataStore, AccountIdentity, AccountIdentity, AccountIdentityAction>
    {
        public AccountIdentityController(IServicer servicer) : base(servicer) { }
    }
}

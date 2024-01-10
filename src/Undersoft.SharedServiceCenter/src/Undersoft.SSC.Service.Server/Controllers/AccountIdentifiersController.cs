using Microsoft.AspNetCore.Authorization;
using Undersoft.SDK.Service.Server.Controller.Crud;
using Undersoft.SDK.Service.Server.Controller.Open;
using Undersoft.SSC.Entities;

namespace Undersoft.SSC.Service.Server.Controllers
{
    [AllowAnonymous]
    public class AccountIdentifierController
        : OpenDataController<long, IEntryStore, IReportStore, Identifier<Account>, Identifier<Contracts.Account>>
    {
        public AccountIdentifierController(IServicer ultimatr) : base(ultimatr) { }
    }
}

namespace Undersoft.SSC.Service.Server.Controllers
{
    public class AccountIdentifiersController
        : CrudDataController<long, IEntryStore, IReportStore, Identifier<Account>, Identifier<Contracts.Account>>
    {
        public AccountIdentifiersController(IServicer ultimatr) : base(ultimatr) { }
    }
}


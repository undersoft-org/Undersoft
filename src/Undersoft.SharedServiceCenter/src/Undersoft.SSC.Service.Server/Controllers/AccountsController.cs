using Microsoft.AspNetCore.Authorization;
using Undersoft.SDK.Service.Server.Controller.Crud;
using Undersoft.SDK.Service.Server.Controller.Open;
using Undersoft.SDK.Service.Server.Controller.Stream;
using Undersoft.SDK.Service.Infrastructure.Store;
using Undersoft.SSC.Entities.Account;

namespace Undersoft.SSC.Service.Server.Controllers
{
    [AllowAnonymous]
    public class AccountController
        : OpenDataController<long, IEntryStore, IReportStore, Account, Contracts.Account>
    {
        public AccountController(IServicer ultimatr) : base(ultimatr) { }
    }
}

namespace Undersoft.SSC.Service.Server.Controllers
{
    public class AccountsController
        : CrudDataController<long, IEntryStore, IReportStore, Account, Contracts.Account>
    {
        public AccountsController(IServicer ultimatr) : base(ultimatr) { }
    }
}

namespace Undersoft.SSC.Service.Server.Controllers
{
    public class AccountStreamController
        : StreamDataController<long, IEntryStore, IReportStore, Account, Contracts.Account>
    {
        public AccountStreamController() : base() { }
    }
}

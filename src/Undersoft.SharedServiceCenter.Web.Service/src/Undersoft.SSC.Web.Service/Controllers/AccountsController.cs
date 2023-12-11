using Microsoft.AspNetCore.Authorization;
using Undersoft.SDK.Service.Application.Controller.Crud;
using Undersoft.SDK.Service.Application.Controller.Open;
using Undersoft.SDK.Service.Application.Controller.Stream;
using Undersoft.SSC.Domain.Entities;

namespace Undersoft.SSC.Web.Controllers
{
    [AllowAnonymous]
    public class AccountController
        : OpenDataController<long, IEntryStore, IReportStore, Account, Contracts.AccountBase>
    {
        public AccountController(IServicer ultimatr) : base(ultimatr) { }
    }
}

namespace Undersoft.SSC.Web.Controllers
{
    public class AccountsController
        : CrudDataController<long, IEntryStore, IReportStore, Account, Web.Contracts.AccountBase>
    {
        public AccountsController(IServicer ultimatr) : base(ultimatr) { }
    }
}

namespace Undersoft.SSC.Web.Controllers
{
    public class AccountStreamController
        : StreamDataController<long, IEntryStore, IReportStore, Account, Web.Contracts.AccountBase>,
            IStreamDataController<Web.Contracts.AccountBase>
    {
        public AccountStreamController() : base() { }
    }
}

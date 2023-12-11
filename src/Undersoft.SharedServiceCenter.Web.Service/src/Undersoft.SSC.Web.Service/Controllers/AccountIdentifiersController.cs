using Microsoft.AspNetCore.Authorization;
using Undersoft.SDK.Service.Application.Controller.Crud;
using Undersoft.SDK.Service.Application.Controller.Open;
using Undersoft.SDK.Service.Application.Controller.Stream;
using Undersoft.SSC.Domain.Entities;

namespace Undersoft.SSC.Web.Controllers
{
    [AllowAnonymous]
    public class AccountIdentifierController
        : OpenDataController<long, IEntryStore, IReportStore, Identifier<Account>, Identifier<Contracts.AccountBase>>
    {
        public AccountIdentifierController(IServicer ultimatr) : base(ultimatr) { }
    }
}

namespace Undersoft.SSC.Web.Controllers
{
    public class AccountIdentifiersController
        : CrudDataController<long, IEntryStore, IReportStore, Identifier<Account>, Identifier<Contracts.AccountBase>>
    {
        public AccountIdentifiersController(IServicer ultimatr) : base(ultimatr) { }
    }
}

namespace Undersoft.SSC.Web.Controllers
{
    public class AccountIdentifierStreamController
        : StreamDataController<long, IEntryStore, IReportStore, Identifier<Account>, Identifier<Contracts.AccountBase>>,
            IStreamDataController<Identifier<Contracts.AccountBase>>
    {
        public AccountIdentifierStreamController() : base() { }
    }
}

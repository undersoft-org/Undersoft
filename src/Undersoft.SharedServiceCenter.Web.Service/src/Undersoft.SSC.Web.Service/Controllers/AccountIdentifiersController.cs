using Microsoft.AspNetCore.Authorization;
using Undersoft.SDK.Service.Application.Controller.Crud;
using Undersoft.SDK.Service.Application.Controller.Open;
using Undersoft.SDK.Service.Application.Controller.Stream;
using Undersoft.SSC.Domain.Entities;

namespace Undersoft.SSC.Web.API.Controllers
{
    [AllowAnonymous]
    public class AccountDataIdentifierController
        : OpenDataController<long, IEntryStore, IReportStore, Identifier<Account>, Identifier<Contracts.Account>>
    {
        public AccountDataIdentifierController(IServicer ultimatr) : base(ultimatr) { }
    }
}

namespace Undersoft.SSC.Web.API.Controllers
{
    public class AccountIdentifiersController
        : CrudDataController<long, IEntryStore, IReportStore, Identifier<Account>, Identifier<Contracts.Account>>
    {
        public AccountIdentifiersController(IServicer ultimatr) : base(ultimatr) { }
    }
}

namespace Undersoft.SSC.Web.API.Controllers
{
    public class AccountIdentifierStreamController
        : StreamDataController<long, IEntryStore, IReportStore, Identifier<Account>, Identifier<Contracts.Account>>,
            IStreamDataController<Identifier<Contracts.Account>>
    {
        public AccountIdentifierStreamController() : base() { }
    }
}

using IdentityModel;
using Undersoft.SDK.Service.Application.Operation.Notification.Handler;
using Undersoft.SDK.Service.Application.Operation.Notification;
using Undersoft.SSC.Domain.Entities;


namespace Undersoft.SSC.Web.API.Aggregates
{
    public class CreateAccountIdentity : CreatedHandler<IEntryStore, Account, Contracts.Account>
    {
        private IServicer _servicer;

        public CreateAccountIdentity(IServicer ultimatr) : base()
        {
            _servicer = ultimatr;
        }


        public override Task? Handle(Created<IEntryStore, Account, Contracts.Account> request, CancellationToken cancellationToken)
        {
            return null;
        }
    }
}

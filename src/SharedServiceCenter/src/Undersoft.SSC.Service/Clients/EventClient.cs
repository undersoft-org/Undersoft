using Microsoft.OData.Edm;
using Undersoft.SDK.Service.Client;
using Undersoft.SDK.Service.Infrastructure.Store.Remote;
using Undersoft.SSC.Domain.Entities;

namespace Undersoft.SSC.Service.Clients;

public class EventClient : OpenDataClient<IEventStore>
{
    public EventClient(Uri serviceUri) : base(serviceUri) { }

    protected override IEdmModel OnModelCreating(IEdmModel builder)
    {
        return base.OnModelCreating(builder);
    }
}

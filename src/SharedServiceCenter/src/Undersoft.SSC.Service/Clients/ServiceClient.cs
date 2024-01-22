using Microsoft.OData.Edm;
using Undersoft.SDK.Service.Client;
using Undersoft.SDK.Service.Infrastructure.Store.Remote;
using Undersoft.SSC.Domain.Entities;

namespace Undersoft.SSC.Service.Clients;

public class ServiceClient : OpenDataClient<IDataStore>
{
    public ServiceClient(Uri serviceUri) : base(serviceUri) { }

    protected override IEdmModel OnModelCreating(IEdmModel builder)
    {
        this.RemoteSetToSet<Domain.Entities.Service, Application>(r => r.LeftEntity, r => r.Id);

        return base.OnModelCreating(builder);
    }
}

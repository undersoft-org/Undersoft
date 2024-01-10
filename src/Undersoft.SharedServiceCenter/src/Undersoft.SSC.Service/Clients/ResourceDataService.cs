using Microsoft.OData.Edm;
using Undersoft.SDK.Service.Infrastructure.Store;

namespace Undersoft.SSC.Service.Clients;

public class ResourceDataService : OpenDataService
{
    public ResourceDataService(Uri serviceUri) : base(serviceUri) { }

    protected override IEdmModel OnModelCreating(IEdmModel builder)
    {
        return base.OnModelCreating(builder);
    }
}
 
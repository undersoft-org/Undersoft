using Microsoft.OData.Edm;
using Undersoft.SDK.Service.Infrastructure.Store.Remote;
using Undersoft.SSC.Domain.Entities;

namespace Undersoft.SSC.Infrastructure.Clients;

public class ApplicationClient : ServiceClient
{
    public ApplicationClient(Uri serviceUri) : base(serviceUri) { }

    protected override IEdmModel OnModelCreating(IEdmModel builder)
    {
        return base.OnModelCreating(builder);
    }
}

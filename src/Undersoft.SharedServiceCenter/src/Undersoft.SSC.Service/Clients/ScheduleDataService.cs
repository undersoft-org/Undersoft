using Microsoft.OData.Edm;
using Undersoft.SDK.Service.Infrastructure.Store;

namespace Undersoft.SSC.Service.Clients;

public class ScheduleDataService : OpenDataService
{
    public ScheduleDataService(Uri serviceUri) : base(serviceUri) { }

    protected override IEdmModel OnModelCreating(IEdmModel builder)
    {
        return base.OnModelCreating(builder);
    }
}

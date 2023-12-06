using Microsoft.OData.Edm;

namespace Undersoft.SSC.Infrastructure.Persistance.Services;

public class OpenDataService : OpenDataService<IDataStore>
{
    public OpenDataService(Uri serviceUri) : base(serviceUri) { }

    protected override IEdmModel OnModelCreating(IEdmModel builder)
    {
        return base.OnModelCreating(builder);
    }
}

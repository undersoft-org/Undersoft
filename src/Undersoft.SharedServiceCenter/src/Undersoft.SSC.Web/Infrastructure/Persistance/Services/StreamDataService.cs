using Microsoft.OData.Edm;

namespace Undersoft.SSC.Web.Infrastructure.Persistance.Services;

public class StreamDataService : StreamDataService<IDataStore>
{
    public StreamDataService(Uri serviceUri) : base(serviceUri) { }
}

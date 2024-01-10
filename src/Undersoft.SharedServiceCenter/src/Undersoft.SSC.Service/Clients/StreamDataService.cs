using Microsoft.OData.Edm;
using Undersoft.SDK.Service.Infrastructure.Store;

namespace Undersoft.SSC.Service.Clients;

public class StreamDataService : StreamDataService<IDataStore>
{
    public StreamDataService(Uri serviceUri) : base(serviceUri) { }
}

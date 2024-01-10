using Microsoft.OData.Edm;
using Undersoft.SDK.Service.Infrastructure.Store;

namespace Undersoft.SSC.Service.Clients;

public class CrudDataService : CrudDataService<IDataStore>
{
    public CrudDataService(Uri serviceUri) : base(serviceUri) { }

}

using Microsoft.OData.Edm;

namespace Undersoft.SSC.Infrastructure.Persistance.Services;

public class CrudDataService : CrudDataService<IDataStore>
{
    public CrudDataService(Uri serviceUri) : base(serviceUri) { }

}

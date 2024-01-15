using Microsoft.EntityFrameworkCore;
using Undersoft.SDK.Service.Infrastructure.Store;

namespace Undersoft.SSC.Service.Platform.Resource.Infrastructure.Stores
{
    public class ServiceReportStore : ServiceDataStore<IReportStore, ServiceReportStore>
    {
        public ServiceReportStore(DbContextOptions<ServiceReportStore> options) : base(options) { }
    }
}

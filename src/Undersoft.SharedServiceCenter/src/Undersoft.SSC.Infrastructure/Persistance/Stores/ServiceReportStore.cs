using Microsoft.EntityFrameworkCore;
using Undersoft.SDK.Service.Data.Store;

namespace Undersoft.SSC.Infrastructure.Persistance.Stores
{
    public class ServiceReportStore : ServiceDataStore<IReportStore, ServiceReportStore>
    {
        public ServiceReportStore(DbContextOptions<ServiceReportStore> options) : base(options) { }
    }
}

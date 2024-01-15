using Microsoft.EntityFrameworkCore;
using Undersoft.SDK.Service.Infrastructure.Store;

namespace Undersoft.SSC.Service.Infrastructure.Stores
{
    public class ServiceReportStore : Store<IReportStore, ServiceReportStore>
    {
        public ServiceReportStore(DbContextOptions<ServiceReportStore> options) : base(options) { }
    }
}

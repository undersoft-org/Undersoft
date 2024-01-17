using Microsoft.EntityFrameworkCore;
using Undersoft.SDK.Service.Infrastructure.Store;

namespace Undersoft.SSC.Service.Infrastructure.Stores
{
    public class ReportStore : StoreBase<IReportStore, ReportStore>
    {
        public ReportStore(DbContextOptions<ReportStore> options) : base(options) { }
    }
}

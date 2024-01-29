using Undersoft.SDK.Service.Infrastructure.Database;
using Undersoft.SDK.Service.Server;
using Undersoft.SSC.Service.Infrastructure.Stores;
using Undersoft.SDK.Service.Data.Store;

namespace Undersoft.SSC.Service.Infrastructure.Stores.Factories;

public class ReportStoreFactory : DbStoreContextFactory<ReportStore, ServerSourceProviderConfiguration> { }

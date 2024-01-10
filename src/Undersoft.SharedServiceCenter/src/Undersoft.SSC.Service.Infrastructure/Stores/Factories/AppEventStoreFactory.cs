using Undersoft.SDK.Service.Infrastructure.Store;
using Undersoft.SDK.Service.Server;

namespace Undersoft.SSC.Service.Infrastructure.Stores.Factories
{
    public class AppEventStoreFactory : DataStoreContextFactory<AppEventStore, ServerSourceProviderConfiguration>
    {
    }
}

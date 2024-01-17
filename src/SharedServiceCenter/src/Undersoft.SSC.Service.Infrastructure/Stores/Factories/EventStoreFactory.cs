using Undersoft.SDK.Service.Infrastructure.Store;
using Undersoft.SDK.Service.Server;
using Undersoft.SSC.Service.Infrastructure.Stores;

namespace Undersoft.SSC.Service.Infrastructure.Stores.Factories
{
    public class EventStoreFactory : DataStoreContextFactory<EventStore, ServerSourceProviderConfiguration>
    {
    }
}

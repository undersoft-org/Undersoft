﻿using Undersoft.SDK.Service.Infrastructure.Store;
using Undersoft.SDK.Service.Server;
using Undersoft.SSC.Service.Infrastructure.Stores;

namespace Undersoft.SSC.Service.Schedule.Infrastructure.Stores.Factories
{
    public class ServiceEventStoreFactory : DataStoreContextFactory<ServiceEventStore, ServerSourceProviderConfiguration>
    {
    }
}

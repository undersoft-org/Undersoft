﻿using Undersoft.SDK.Service.Infrastructure.Store;
using Undersoft.SDK.Service.Server;
using Undersoft.SSC.Service.Activity.Infrastructure.Stores;
using Undersoft.SSC.Service.Infrastructure.Stores;

namespace Undersoft.SSC.Service.Activity.Infrastructure.Stores.Factories
{
    public class ServiceEventStoreFactory : DataStoreContextFactory<ServiceEventStore, ServerSourceProviderConfiguration>
    {
    }
}

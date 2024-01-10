using System;
using Undersoft.SDK.Service.Infrastructure.Store;

namespace Undersoft.SDK.Service.Client
{
    public partial class OpenDataService<TStore> : OpenDataServiceContext where TStore : IDataServiceStore
    {
        public OpenDataService(Uri serviceUri) : base(serviceUri)
        {
        }
    }
}
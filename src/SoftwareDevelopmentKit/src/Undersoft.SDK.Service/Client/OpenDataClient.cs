using System;
using Undersoft.SDK.Service.Infrastructure.Store;

namespace Undersoft.SDK.Service.Client
{
    public partial class OpenDataClient<TStore> : OpenDataContext where TStore : IDataServiceStore
    {
        public OpenDataClient(Uri serviceUri) : base(serviceUri)
        {
        }
    }
}
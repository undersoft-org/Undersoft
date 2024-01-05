using System;
using Undersoft.SDK.Service.Data.Store;

namespace Undersoft.SDK.Service.Data.Service
{
    public partial class OpenDataService<TStore> : OpenDataServiceContext where TStore : IDataServiceStore
    {
        public OpenDataService(Uri serviceUri) : base(serviceUri)
        {
        }
    }
}
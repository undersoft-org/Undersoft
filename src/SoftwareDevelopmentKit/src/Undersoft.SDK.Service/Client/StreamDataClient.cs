using Microsoft.OData.Edm;
using System;
using Undersoft.SDK.Service.Infrastructure.Store;

namespace Undersoft.SDK.Service.Client
{
    public partial class StreamDataClient<TStore> where TStore : IDataServiceStore
    {
        public StreamDataClient(Uri serviceUri)
        {
        }
    }
}
using Microsoft.OData.Edm;
using System;
using Undersoft.SDK.Service.Infrastructure.Store;

namespace Undersoft.SDK.Service.Client
{
    public partial class CrudDataService<TStore> where TStore : IDataServiceStore
    {
        public CrudDataService(Uri serviceUri)
        {
        }
    }
}
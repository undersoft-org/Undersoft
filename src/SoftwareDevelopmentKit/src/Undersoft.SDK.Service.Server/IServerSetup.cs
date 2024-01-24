using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Undersoft.SDK.Service.Server
{
    using Undersoft.SDK.Service.Infrastructure.Store;

    public partial interface IServerSetup : IServiceSetup
    {
        IServerSetup AddDataServer<TServiceStore>(
            DataServerTypes dataServiceTypes,
            Action<DataServerBuilder> builder = null
        ) where TServiceStore : IDataStore;
        IServerSetup AddAccountServer<TContext>() where TContext : DbContext;
        IServerSetup AddAuthentication();
        IServerSetup AddAuthorization();
        IServerSetup UseDataServices();
        IServerSetup AddApiVersions(string[] apiVersions);
        IServerSetup ConfigureServer(bool includeSwagger, Assembly[] assemblies = null, Type[] sourceTypes = null, Type[] clientTypes = null);
    }
}

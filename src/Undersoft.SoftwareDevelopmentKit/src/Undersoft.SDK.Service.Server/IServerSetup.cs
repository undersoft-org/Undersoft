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
        ) where TServiceStore : IDataServiceStore;
        IServerSetup AddAccountIdentity<TContext>() where TContext : DbContext;
        IServerSetup AddIdentityAuthentication();
        IServerSetup AddIdentityAuthorization();
        IServerSetup UseDataServices();
        IServerSetup AddApiVersions(string[] apiVersions);
        IServerSetup ConfigureServer(bool includeSwagger, Assembly[] assemblies = null, Type[] sourceTypes = null, Type[] clientTypes = null);
    }
}

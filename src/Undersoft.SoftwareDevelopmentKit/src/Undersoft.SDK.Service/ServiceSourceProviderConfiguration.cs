using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.DependencyInjection;
using Undersoft.SDK.Service.Data.Repository.Source;
using Undersoft.SDK.Service.Data.Store;

namespace Undersoft.SDK.Service
{
    public class ServiceSourceProviderConfiguration : ISourceProviderConfiguration
    {
        public virtual IServiceRegistry AddSourceProvider(SourceProvider provider)
        {
            IServiceRegistry registry = ServiceManager.GetRegistry();
            if (!DataStoreRegistry.SourceProviders.ContainsKey((int)provider))
            {
                switch (provider)
                {
                    case SourceProvider.MemoryDb:
                        registry.AddEntityFrameworkInMemoryDatabase();
                        break;
                    case SourceProvider.SqlLite:
                        registry.AddEntityFrameworkSqlite();
                        break;
                    default:
                        break;
                }
                registry.AddEntityFrameworkProxies();
                DataStoreRegistry.SourceProviders.Add((int)provider, provider);
            }
            return registry;
        }

        public virtual DbContextOptionsBuilder BuildOptions(
         DbContextOptionsBuilder builder,
         SourceProvider provider,
         string connectionString)
        {
            switch (provider)
            {                
                case SourceProvider.MemoryDb:
                    return builder.UseInternalServiceProvider(new ServiceManager())
                        .UseInMemoryDatabase(connectionString)
                        .UseLazyLoadingProxies()
                        .ConfigureWarnings(
                            w => w.Ignore(
                                InMemoryEventId
                                .TransactionIgnoredWarning));
                default:
                    break;
            }

            return builder;
        }
    }
}

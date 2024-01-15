using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.DependencyInjection;
using Undersoft.SDK.Service.Infrastructure.Repository.Source;
using Undersoft.SDK.Service.Infrastructure.Store;

namespace Undersoft.SDK.Service
{
    public class ServiceSourceProviderConfiguration : ISourceProviderConfiguration
    {
        public ServiceSourceProviderConfiguration() { }

        public ServiceSourceProviderConfiguration(IServiceRegistry registry) { _registry = registry; }

        IServiceRegistry _registry { get; set; }
        
        public virtual IServiceRegistry AddSourceProvider(SourceProvider provider)
        {            
            if (!DataStoreRegistry.SourceProviders.ContainsKey((int)provider))
            {
                switch (provider)
                {
                    case SourceProvider.MemoryDb:
                        _registry.AddEntityFrameworkInMemoryDatabase();
                        break;
                    case SourceProvider.SqlLite:
                        _registry.AddEntityFrameworkSqlite();
                        break;
                    default:
                        break;
                }
                _registry.AddEntityFrameworkProxies();
                DataStoreRegistry.SourceProviders.Add((int)provider, provider);
            }
            return _registry;
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

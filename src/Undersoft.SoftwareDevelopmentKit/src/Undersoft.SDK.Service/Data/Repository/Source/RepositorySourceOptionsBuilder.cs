using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.DependencyInjection;
using Undersoft.SDK.Service.Data.Store;

namespace Undersoft.SDK.Service.Data.Repository.Source
{
    public static class RepositorySourceOptionsBuilder
    {
        public static IServiceRegistry AddEntityFrameworkSourceProvider<TSourceProvider>(SourceProvider provider) where TSourceProvider : class, ISourceProviderConfiguration
        {
            
            var sourceConfiguration = typeof(TSourceProvider).New<TSourceProvider>();            
            sourceConfiguration.AddSourceProvider(provider);
            var registry = ServiceManager.GetRegistry();
            registry.AddObject<ISourceProviderConfiguration>(sourceConfiguration);
            return registry;
        }

        public static IServiceRegistry AddEntityFrameworkSourceProvider(SourceProvider provider)
        {
            var registry = ServiceManager.GetRegistry();
            var sourceConfiguration = registry.GetObject<ISourceProviderConfiguration>();           
            sourceConfiguration.AddSourceProvider(provider);

            return registry;
        }

        public static DbContextOptionsBuilder<TContext> BuildOptions<TContext>(
            SourceProvider provider,
            string connectionString)
            where TContext : DbContext
        {
            var builder = ServiceManager.GetRegistry().GetObject<ISourceProviderConfiguration>();

            return (DbContextOptionsBuilder<TContext>)builder.BuildOptions(
                new DbContextOptionsBuilder<TContext>(),
                provider,
                connectionString)
                .ConfigureWarnings(w => w.Ignore(CoreEventId.DetachedLazyLoadingWarning));
        }

        public static DbContextOptionsBuilder BuildOptions(SourceProvider provider, string connectionString)
        {
            var builder = ServiceManager.GetRegistry().GetObject<ISourceProviderConfiguration>();

            return builder.BuildOptions(new DbContextOptionsBuilder(), provider, connectionString)
                .ConfigureWarnings(w => w.Ignore(CoreEventId.DetachedLazyLoadingWarning));
        }       
    }

    public enum SourceProvider
    {
        None,
        SqlServer,
        MemoryDb,
        AzureSql,
        PostgreSql,
        SqlLite,
        MySql,
        MariaDb,
        Oracle,
        CosmosDb,
        MongoDb,
        FileSystem
    }

    public enum ClientProvider
    {
        None,
        Open,
        Crud,
        Stream
    }
}

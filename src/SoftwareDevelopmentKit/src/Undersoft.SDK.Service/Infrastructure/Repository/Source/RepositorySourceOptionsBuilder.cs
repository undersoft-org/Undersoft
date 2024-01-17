using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Undersoft.SDK.Service.Infrastructure.Repository.Source
{
    public static class RepositorySourceOptionsBuilder
    {
        public static void AddRootEntityFrameworkSourceProvider<TSourceProvider>(SourceProvider provider) where TSourceProvider : class, ISourceProviderConfiguration
        {
            var sourceConfiguration = typeof(TSourceProvider).New<TSourceProvider>(ServiceManager.GetRootManager().Registry);
            sourceConfiguration.AddSourceProvider(provider);
            ServiceManager.AddRootObject<ISourceProviderConfiguration>(sourceConfiguration);
        }

        public static ISourceProviderConfiguration AddEntityFrameworkSourceProvider(SourceProvider provider)
        {
            var sourceConfiguration = ServiceManager.GetRootObject<ISourceProviderConfiguration>();
            sourceConfiguration.AddSourceProvider(provider);
            return sourceConfiguration;
        }

        public static ISourceProviderConfiguration AddEntityFrameworkSourceProvider(this IServiceRegistry registry, SourceProvider provider)
        {
            var sourceConfiguration = registry.GetObject<ISourceProviderConfiguration>();
            sourceConfiguration.AddSourceProvider(provider);
            return sourceConfiguration;
        }

        public static DbContextOptionsBuilder<TContext> BuildOptions<TContext>(
            SourceProvider provider,
            string connectionString)
            where TContext : DbContext
        {
            var builder = ServiceManager.GetRootObject<ISourceProviderConfiguration>();

            return (DbContextOptionsBuilder<TContext>)builder.BuildOptions(
                new DbContextOptionsBuilder<TContext>(),
                provider,
                connectionString)
                .ConfigureWarnings(w => w.Ignore(CoreEventId.DetachedLazyLoadingWarning));
        }

        public static DbContextOptionsBuilder BuildOptions(SourceProvider provider, string connectionString)
        {
            var builder = ServiceManager.GetRootObject<ISourceProviderConfiguration > ();

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

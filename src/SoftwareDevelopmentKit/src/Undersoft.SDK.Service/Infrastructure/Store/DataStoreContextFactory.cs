using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;

namespace Undersoft.SDK.Service.Infrastructure.Store;

using Configuration;
using Undersoft.SDK.Service.Infrastructure.Repository;
using Undersoft.SDK.Service.Infrastructure.Repository.Source;

public class DataStoreContextFactory<TContext, TSourceProvider> : IDesignTimeDbContextFactory<TContext>, IDbContextFactory<TContext> where TContext : DbContext where TSourceProvider : class, ISourceProviderConfiguration
{
    public TContext CreateDbContext(string[] args)
    {
        var config = new ServiceConfiguration();
        var configSource = config.Source(typeof(TContext).FullName);
        var provider = config.SourceProvider(configSource);
        RepositorySourceOptionsBuilder.AddEntityFrameworkSourceProvider<TSourceProvider>(provider);
        var options = RepositorySourceOptionsBuilder.BuildOptions<TContext>(provider, config.SourceConnectionString(configSource)).Options;
        return typeof(TContext).New<TContext>(options);
    }

    public TContext CreateDbContext()
    {
        return this.CreateDbContext(null);
    }
}
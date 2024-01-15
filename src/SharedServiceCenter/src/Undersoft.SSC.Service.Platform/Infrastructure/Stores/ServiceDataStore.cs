using Microsoft.EntityFrameworkCore;

namespace Undersoft.SSC.Service.Platform.Infrastructure.Stores;

using Undersoft.SDK.Service.Infrastructure.Store;
using Undersoft.SSC.Entities.Platforms;
using Undersoft.SSC.Entities.Platforms.Locations;
using Undersoft.SSC.Service.Infrastructure.Stores.Mappings;

public class ServiceDataStore<TStore, TContext> : Store<TStore, TContext>
    where TStore : IDataServerStore
    where TContext : DbContext
{
    public ServiceDataStore(DbContextOptions<TContext> options) : base(options) { }

    public virtual DbSet<Platform>? Platforms { get; set; }
    public virtual DbSet<PlatformDetail>? Details { get; set; }
    public virtual DbSet<PlatformSetting>? Settings { get; set; }
    public virtual DbSet<PlatformDefault>? Defaults { get; set; }
    public virtual DbSet<PlatformLocation>? Locations { get; set; }
    public virtual DbSet<Endpoint>? Endpoints { get; set; }
    public virtual DbSet<Position>? Positions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyMapping(new PlatformMappings());
        base.OnModelCreating(modelBuilder);
    }
}

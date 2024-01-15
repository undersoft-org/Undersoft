using Microsoft.EntityFrameworkCore;

namespace Undersoft.SSC.Service.Platform.Resource.Infrastructure.Stores;

using Service.Infrastructure.Stores.Mappings;
using Undersoft.SDK.Service.Infrastructure.Store;
using Undersoft.SSC.Entities.Members;
using Undersoft.SSC.Entities.Resources;
using Undersoft.SSC.Entities.Resources.Locations;

public class ServiceDataStore<TStore, TContext> : Store<TStore, TContext>
    where TStore : IDataServerStore
    where TContext : DbContext
{
    public ServiceDataStore(DbContextOptions<TContext> options) : base(options) { }

    public virtual DbSet<Resource>? Resources { get; set; }
    public virtual DbSet<ResourceDetail>? Details { get; set; }
    public virtual DbSet<ResourceSetting>? Settings { get; set; }
    public virtual DbSet<ResourceDefault>? Defaults { get; set; }
    public virtual DbSet<ResourceLocation>? Locations { get; set; }
    public virtual DbSet<Endpoint>? Endpoints { get; set; }
    public virtual DbSet<Position>? Positions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyMapping(new ResourceMappings());
        base.OnModelCreating(modelBuilder);
    }
}

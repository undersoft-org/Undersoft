using Microsoft.EntityFrameworkCore;

namespace Undersoft.SSC.Service.Platform.Activity.Infrastructure.Stores;

using Service.Infrastructure.Stores.Mappings;
using Undersoft.SDK.Service.Infrastructure.Store;
using Undersoft.SSC.Entities.Activities;
using Undersoft.SSC.Entities.Activities.Locations;

public class ServiceDataStore<TStore, TContext> : Store<TStore, TContext>
    where TStore : IDataServerStore
    where TContext : DbContext
{
    public ServiceDataStore(DbContextOptions<TContext> options) : base(options) { }

    public virtual DbSet<Activity>? Activities { get; set; }
    public virtual DbSet<ActivityDetail>? Details { get; set; }
    public virtual DbSet<ActivitySetting>? Settings { get; set; }
    public virtual DbSet<ActivityDefault>? Defaults { get; set; }
    public virtual DbSet<ActivityLocation>? Locations { get; set; }
    public virtual DbSet<Endpoint>? Endpoints { get; set; }
    public virtual DbSet<Position>? Positions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyMapping(new ActivityMappings());
        base.OnModelCreating(modelBuilder);
    }
}

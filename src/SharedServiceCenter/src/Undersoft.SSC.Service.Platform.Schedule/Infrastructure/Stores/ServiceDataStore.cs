using Microsoft.EntityFrameworkCore;

namespace Undersoft.SSC.Service.Platform.Schedule.Infrastructure.Stores;

using Service.Infrastructure.Stores.Mappings;
using Undersoft.SDK.Service.Infrastructure.Store;
using Undersoft.SSC.Entities.Schedules;
using Undersoft.SSC.Entities.Schedules.Locations;

public class ServiceDataStore<TStore, TContext> : Store<TStore, TContext>
    where TStore : IDataServerStore
    where TContext : DbContext
{
    public ServiceDataStore(DbContextOptions<TContext> options) : base(options) { }

    public virtual DbSet<Schedule>? Schedules { get; set; }
    public virtual DbSet<ScheduleDetail>? Details { get; set; }
    public virtual DbSet<ScheduleSetting>? Settings { get; set; }
    public virtual DbSet<ScheduleDefault>? Defaults { get; set; }
    public virtual DbSet<ScheduleLocation>? Locations { get; set; }
    public virtual DbSet<Endpoint>? Endpoints { get; set; }
    public virtual DbSet<Position>? Positions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyMapping(new ScheduleMappings());
        base.OnModelCreating(modelBuilder);
    }
}

using Microsoft.EntityFrameworkCore;

namespace Undersoft.SSC.Service.Schedule.Infrastructure.Stores;

using Service.Infrastructure.Stores.Mappings;
using Service.Infrastructure.Stores.Mappings.Locations;
using Undersoft.SDK.Service.Infrastructure.Store;
using Undersoft.SSC.Entities.Schedules;

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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyMapping(new ScheduleMappings());
        modelBuilder.ApplyMapping(new AddressMapping());
        modelBuilder.ApplyMapping(new CountryMapping());
        modelBuilder.ApplyMapping(new CountryStateMapping());
        modelBuilder.ApplyMapping(new CurrencyMapping());
        modelBuilder.ApplyMapping(new LanguageMapping());
        modelBuilder.ApplyMapping(new EndpointMapping());
        base.OnModelCreating(modelBuilder);
    }
}

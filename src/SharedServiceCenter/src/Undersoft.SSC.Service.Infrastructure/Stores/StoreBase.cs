using Microsoft.EntityFrameworkCore;

namespace Undersoft.SSC.Service.Infrastructure.Stores;

using Undersoft.SDK.Service.Infrastructure.Store;
using Undersoft.SSC.Domain.Entities;
using Undersoft.SSC.Domain.Entities.Locations;
using Undersoft.SSC.Service.Infrastructure.Stores.Mappings;
using Undersoft.SSC.Service.Infrastructure.Stores.Mappings.Locations;

public class StoreBase<TStore, TContext> : Store<TStore, TContext>
    where TStore : IDataServerStore
    where TContext : DbContext
{
    public StoreBase(DbContextOptions<TContext> options) : base(options) { }

    public virtual DbSet<Application>? Applications { get; set; }
    public virtual DbSet<Platform>? Platforms { get; set; }
    public virtual DbSet<Equipment>? Equipment { get; set; }
    public virtual DbSet<Infrastructure>? Infrastructures { get; set; }
    public virtual DbSet<Service>? Services { get; set; }
    public virtual DbSet<Member>? Members { get; set; }
    public virtual DbSet<Activity>? Activities { get; set; }
    public virtual DbSet<Resource>? Resources { get; set; }
    public virtual DbSet<Schedule>? Schedules { get; set; }
    public virtual DbSet<Detail>? Details { get; set; }
    public virtual DbSet<Setting>? Settings { get; set; }
    public virtual DbSet<Default>? Defaults { get; set; }
    public virtual DbSet<Location>? Locations { get; set; }
    public virtual DbSet<Endpoint>? Endpoints { get; set; }
    public virtual DbSet<Position>? Positions { get; set; }
    public virtual DbSet<Country>? Countries { get; set; }
    public virtual DbSet<CountryState>? CountryStates { get; set; }
    public virtual DbSet<Currency>? Currencies { get; set; }
    public virtual DbSet<Language>? Languages { get; set; }
    public virtual DbSet<Address>? Addresses { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyMapping(new ApplicationMappings());
        modelBuilder.ApplyMapping(new PlatformMappings());
        modelBuilder.ApplyMapping(new EquipmentMappings());
        modelBuilder.ApplyMapping(new InfrastructureMappings());
        modelBuilder.ApplyMapping(new ServiceMappings());
        modelBuilder.ApplyMapping(new MemberMappings());
        modelBuilder.ApplyMapping(new ActivityMappings());
        modelBuilder.ApplyMapping(new ResourceMappings());
        modelBuilder.ApplyMapping(new ScheduleMappings());
        modelBuilder.ApplyMapping(new DetailMappings());
        modelBuilder.ApplyMapping(new SettingMappings());
        modelBuilder.ApplyMapping(new LocationMappings());
        modelBuilder.ApplyMapping(new DefaultMappings());
        modelBuilder.ApplyMapping(new AddressMappings());
        modelBuilder.ApplyMapping(new CountryMappings());
        modelBuilder.ApplyMapping(new CountryStateMappings());
        modelBuilder.ApplyMapping(new LanguageMappings());
        modelBuilder.ApplyMapping(new CurrencyMappings());
        modelBuilder.ApplyMapping(new EndpointMappings());
        modelBuilder.ApplyMapping(new PositionMappings());

        base.OnModelCreating(modelBuilder);
    }
}

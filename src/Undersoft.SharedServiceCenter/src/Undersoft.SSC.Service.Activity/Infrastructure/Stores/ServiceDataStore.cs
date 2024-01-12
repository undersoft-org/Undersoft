using Microsoft.EntityFrameworkCore;

namespace Undersoft.SSC.Service.Activity.Infrastructure.Stores;

using Service.Infrastructure.Stores.Mappings;
using Service.Infrastructure.Stores.Mappings.Locations;
using Undersoft.SDK.Service.Infrastructure.Store;
using Undersoft.SSC.Entities.Accounts;
using Undersoft.SSC.Entities.Activity;

public class ServiceDataStore<TStore, TContext> : Store<TStore, TContext>
    where TStore : IDatabaseStore
    where TContext : DbContext
{
    public ServiceDataStore(DbContextOptions<TContext> options) : base(options) { }

    public virtual DbSet<Activity>? Activities { get; set; }
    public virtual DbSet<Detail>? Details { get; set; }
    public virtual DbSet<Setting>? Settings { get; set; }
    public virtual DbSet<Default>? Defaults { get; set; }
    public virtual DbSet<AccountLocation>? Locations { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyMapping(new ActivityMappings());
        modelBuilder.ApplyMapping(new DetailMappings());
        modelBuilder.ApplyMapping(new DefaultMappings());
        modelBuilder.ApplyMapping(new SettingMappings());
        modelBuilder.ApplyMapping(new LocationMapping());
        modelBuilder.ApplyMapping(new AddressMapping());
        modelBuilder.ApplyMapping(new CountryMapping());
        modelBuilder.ApplyMapping(new CountryStateMapping());
        modelBuilder.ApplyMapping(new CurrencyMapping());
        modelBuilder.ApplyMapping(new LanguageMapping());
        modelBuilder.ApplyMapping(new EndpointMapping());
        base.OnModelCreating(modelBuilder);
    }
}

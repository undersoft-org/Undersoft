using Microsoft.EntityFrameworkCore;

namespace Undersoft.SSC.Service.Activity.Infrastructure.Stores;

using Service.Infrastructure.Stores.Mappings;
using Service.Infrastructure.Stores.Mappings.Locations;
using Undersoft.SDK.Service.Infrastructure.Store;
using Undersoft.SSC.Entities.Activities;

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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyMapping(new ActivityMappings());
        modelBuilder.ApplyMapping(new AddressMapping());
        modelBuilder.ApplyMapping(new CountryMapping());
        modelBuilder.ApplyMapping(new CountryStateMapping());
        modelBuilder.ApplyMapping(new CurrencyMapping());
        modelBuilder.ApplyMapping(new LanguageMapping());
        modelBuilder.ApplyMapping(new EndpointMapping());
        base.OnModelCreating(modelBuilder);
    }
}

using Microsoft.EntityFrameworkCore;

namespace Undersoft.SSC.Service.Account.Infrastructure.Stores;

using Service.Infrastructure.Stores.Mappings;
using Service.Infrastructure.Stores.Mappings.Locations;
using Undersoft.SDK.Service.Infrastructure.Store;
using Undersoft.SSC.Entities;

public class ServiceDataStore<TStore, TContext> : Store<TStore, TContext>
    where TStore : IDatabaseStore
    where TContext : DbContext
{
    public ServiceDataStore(DbContextOptions<TContext> options) : base(options) { }

    public virtual DbSet<Account>? Accounts { get; set; }
    public virtual DbSet<Detail>? Details { get; set; }
    public virtual DbSet<Setting>? Settings { get; set; }
    public virtual DbSet<Default>? Defaults { get; set; }
    public virtual DbSet<Location>? Locations { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyMapping(new AccountMappings());
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

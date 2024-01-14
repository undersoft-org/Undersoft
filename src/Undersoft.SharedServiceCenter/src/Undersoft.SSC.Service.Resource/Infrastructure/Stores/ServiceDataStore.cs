using Microsoft.EntityFrameworkCore;

namespace Undersoft.SSC.Service.Resource.Infrastructure.Stores;

using Service.Infrastructure.Stores.Mappings;
using Service.Infrastructure.Stores.Mappings.Locations;
using Undersoft.SDK.Service.Infrastructure.Store;
using Undersoft.SSC.Entities.Members;
using Undersoft.SSC.Entities.Resources;

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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyMapping(new ResourceMappings());
        modelBuilder.ApplyMapping(new AddressMapping());
        modelBuilder.ApplyMapping(new CountryMapping());
        modelBuilder.ApplyMapping(new CountryStateMapping());
        modelBuilder.ApplyMapping(new CurrencyMapping());
        modelBuilder.ApplyMapping(new LanguageMapping());
        modelBuilder.ApplyMapping(new EndpointMapping());
        base.OnModelCreating(modelBuilder);
    }
}

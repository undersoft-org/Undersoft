using Microsoft.EntityFrameworkCore;

namespace Undersoft.SSC.Service.Platform.Member.Infrastructure.Stores;

using Service.Infrastructure.Stores.Mappings.Locations;
using Undersoft.SDK.Service.Infrastructure.Store;
using Undersoft.SSC.Entities.Members;
using Undersoft.SSC.Entities.Members.Locations;
using Undersoft.SSC.Service.Infrastructure.Stores.Mappings;

public class ServiceDataStore<TStore, TContext> : Store<TStore, TContext>
    where TStore : IDataServerStore
    where TContext : DbContext
{
    public ServiceDataStore(DbContextOptions<TContext> options) : base(options) { }

    public virtual DbSet<Member>? Members { get; set; }
    public virtual DbSet<MemberDetail>? Details { get; set; }
    public virtual DbSet<MemberSetting>? Settings { get; set; }
    public virtual DbSet<MemberDefault>? Defaults { get; set; }
    public virtual DbSet<MemberLocation>? Locations { get; set; }
    public virtual DbSet<Country>? Countries { get; set; }
    public virtual DbSet<CountryState>? CountryStates { get; set; }
    public virtual DbSet<Currency>? Currencies { get; set; }
    public virtual DbSet<Language>? Languages { get; set; }
    public virtual DbSet<Address>? Addresses { get; set; }
    public virtual DbSet<Endpoint>? Endpoints { get; set; }
    public virtual DbSet<Position>? Positions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyMapping(new MemberMappings());
        modelBuilder.ApplyMapping(new AddressMapping());
        modelBuilder.ApplyMapping(new CountryMapping());
        modelBuilder.ApplyMapping(new CountryStateMapping());
        modelBuilder.ApplyMapping(new CurrencyMapping());
        modelBuilder.ApplyMapping(new LanguageMapping());
        modelBuilder.ApplyMapping(new PositionMapping());
        modelBuilder.ApplyMapping(new EndpointMapping());
        base.OnModelCreating(modelBuilder);
    }
}

using Microsoft.EntityFrameworkCore;

namespace Undersoft.SDK.Service.Infrastructure.Store;

public partial class Store<TStore, TContext> : DataStoreContext<TStore> where TStore : IDatabaseStore
    where TContext : DbContext
{
    public Store(DbContextOptions<TContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyIdentity<TContext>();
        base.OnModelCreating(modelBuilder);
    }
}

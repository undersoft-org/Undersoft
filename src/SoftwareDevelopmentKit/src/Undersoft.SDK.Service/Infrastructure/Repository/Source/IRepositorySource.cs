using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Undersoft.SDK.Service.Infrastructure.Repository;
using Undersoft.SDK.Service.Infrastructure.Store;

namespace Undersoft.SDK.Service.Infrastructure.Repository.Source
{
    public interface IRepositorySource<TStore, TEntity> : IRepositorySource where TEntity : class, IUniqueIdentifiable
    {
        IQueryable<TEntity> FromSql(string sql, params object[] parameters);

        DbSet<TEntity> EntitySet();
    }

    public interface IRepositorySource : IRepositoryContextPool
    {
        IDataStoreContext Context { get; }
        DbContextOptions Options { get; }
        bool Pooled { get; }

        void AcquireAccess();
        IDataStoreContext CreateContext(DbContextOptions options);
        IDataStoreContext CreateContext(Type contextType, DbContextOptions options);
        TContext CreateContext<TContext>(DbContextOptions options) where TContext : DbContext;
        void CreatePool<TContext>();
        object EntitySet(Type entityType);
        object EntitySet<TEntity>() where TEntity : class, IUniqueIdentifiable;
        TContext GetContext<TContext>() where TContext : DbContext;
        void ReleaseAccess();
    }

    public interface IRepositorySource<TContext> : IRepositoryContextPool<TContext>, IDesignTimeDbContextFactory<TContext>, IDbContextFactory<TContext>, IRepositorySource
        where TContext : DbContext
    {
        TContext CreateContext(DbContextOptions<TContext> options);

        new DbContextOptions<TContext> Options { get; }
    }
}

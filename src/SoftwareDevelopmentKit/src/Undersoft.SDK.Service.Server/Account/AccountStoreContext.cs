using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Undersoft.SDK.Logging;
using Undersoft.SDK.Service.Infrastructure.Store;
using Undersoft.SDK.Uniques;

namespace Undersoft.SDK.Service.Server.Account;

public partial class AccountStore<TStore, TContext> : AccountStoreContext<TStore>
    where TStore : IDataServerStore
    where TContext : DbContext
{
    public AccountStore(DbContextOptions<TContext> options) : base(options) { }
}

public partial class AccountStoreContext<TStore>
    : IdentityDbContext<
        AccountUser,
        Role,
        long,
        AccountClaim,
        AccountRole,
        AccountLogin,
        RoleClaim,
        AccountToken
    >,
        IDataStoreContext<TStore> where TStore : IDataServerStore
{
    public AccountStoreContext(DbContextOptions options) : base(options) { }

    public virtual DbSet<Account> Accounts { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.HasDefaultSchema("Account");
        builder
            .ApplyMapping<Account>(new AccountMappings())
            .ApplyMapping<AccountClaim>(new AccountClaimMappings())
            .ApplyMapping<AccountToken>(new AccountTokenMappings())
            .ApplyMapping<Role>(new RolemMappings());

        builder.Entity<Account>(entity =>
        {
            entity.ToTable(name: "Accounts");
        });
        builder.Entity<AccountUser>(entity =>
        {
            entity.ToTable(name: "AccountUsers");
        });
        builder.Entity<Role>(entity =>
        {
            entity.ToTable(name: "Roles");
        });
        builder.Entity<AccountRole>(entity =>
        {
            entity.ToTable("AccountRoles");
        });
        builder.Entity<AccountClaim>(entity =>
        {
            entity.ToTable("AccountClaims");
        });
        builder.Entity<AccountLogin>(entity =>
        {
            entity.ToTable("AccountLogins");
        });
        builder.Entity<RoleClaim>(entity =>
        {
            entity.ToTable("RoleClaims");
        });
        builder.Entity<AccountToken>(entity =>
        {
            entity.ToTable("AccountTokens");
        });
    }

    public object EntitySet<TEntity>() where TEntity : class, IUniqueIdentifiable
    {
        return Set<TEntity>();
    }

    public object EntitySet(Type type)
    {
        return this.GetEntitySet(type);
    }

    public virtual Task<int> Save(bool asTransaction, CancellationToken token = default)
    {
        return saveEndpoint(asTransaction, token);
    }

    private async Task<int> saveEndpoint(bool asTransaction, CancellationToken token = default)
    {
        if (ChangeTracker.HasChanges())
        {
            if (asTransaction)
                return await saveAsTransaction(token);
            else
                return await saveChanges(token);
        }
        return 0;
    }

    private async Task<int> saveAsTransaction(CancellationToken token = default)
    {
        await using var tr = await Database.BeginTransactionAsync(token);
        try
        {
            var changes = await SaveChangesAsync(token);

            await tr.CommitAsync(token);

            return changes;
        }
        catch (DbUpdateException e)
        {
            if (e is DbUpdateConcurrencyException)
                tr.Warning<Datalog>(
                    $"Concurrency update exception data changed by: {e.Source}, "
                        + $"entries involved in detail data object",
                    e.Entries,
                    e
                );
            else
                tr.Failure<Datalog>(
                    $"Fail on update database transaction Id:{tr.TransactionId}, using context:{GetType().Name},"
                        + $" context Id:{ContextId}, TimeStamp:{DateTime.Now.ToString()} {e.StackTrace}",
                    e.Entries
                );

            await tr.RollbackAsync(token);

            tr.Warning<Datalog>($"Transaction Id:{tr.TransactionId} Rolling Back !!");
        }
        return -1;
    }

    private async Task<int> saveChanges(CancellationToken token = default)
    {
        try
        {
            return await SaveChangesAsync(token);
        }
        catch (DbUpdateException e)
        {
            if (e is DbUpdateConcurrencyException)
                this.Warning<Datalog>(
                    $"Concurrency update exception data changed by: {e.Source}, "
                        + $"entries involved in detail data object",
                    e.Entries,
                    e
                );
            else
                this.Failure<Datalog>(
                    $"Fail on update database, using context:{GetType().Name}, "
                        + $"context Id: {ContextId}, TimeStamp: {DateTime.Now.ToString()}"
                );
        }

        return -1;
    }
}

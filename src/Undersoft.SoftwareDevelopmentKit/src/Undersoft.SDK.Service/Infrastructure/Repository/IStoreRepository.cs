using Microsoft.EntityFrameworkCore.Storage;

namespace Undersoft.SDK.Service.Infrastructure.Repository
{
    public interface IStoreRepository<TStore, TEntity> : IStoreRepository<TEntity> where TEntity : class, IOrigin
    {
    }

    public interface IStoreRepository<TEntity> : IRepository<TEntity> where TEntity : class, IOrigin
    {
        IDbContextTransaction BeginTransaction();
        Task<IDbContextTransaction> BeginTransactionAsync();
        void CommitTransaction(IDbContextTransaction transaction);
        Task CommitTransaction(Task<IDbContextTransaction> transaction);
    }
}
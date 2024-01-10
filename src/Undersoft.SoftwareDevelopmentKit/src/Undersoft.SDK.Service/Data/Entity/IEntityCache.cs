using System;
using Undersoft.SDK.Service.Infrastructure.Store;

namespace Undersoft.SDK.Service.Data.Entity;

public interface IEntityCache<TStore, TEntity> : IStoreCache<TStore>
{
}
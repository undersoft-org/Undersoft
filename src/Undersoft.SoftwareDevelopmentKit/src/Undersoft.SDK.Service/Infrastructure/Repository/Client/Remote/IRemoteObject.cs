using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Threading.Tasks;

namespace Undersoft.SDK.Service.Infrastructure.Repository.Client.Remote;

using Data.Entity;
using Undersoft.SDK;
using Undersoft.SDK.Service.Infrastructure.Repository;
using Undersoft.SDK.Service.Infrastructure.Store;
using Undersoft.SDK.Service.Infrastructure.Store.Remote;

public interface IRemoteObject<TStore, TOrigin> : IRemoteObject<TOrigin> where TOrigin : class, IOrigin where TStore : IDataServiceStore
{
}

public interface IRemoteObject<TOrigin> : IRemoteObject where TOrigin : class, IOrigin
{
}

public interface IRemoteObject : IRepository, IRemoteLink
{
    bool IsLinked { get; set; }

    IRepository Host { get; set; }

    void Load(object origin);

    Task LoadAsync(object origin);

    void LinkTrigger(object sender, EntityEntryEventArgs e);

    IRemoteSynchronizer Synchronizer { get; }
}

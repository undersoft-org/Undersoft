using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Threading.Tasks;

namespace Undersoft.SDK.Service.Infrastructure.Repository.Client.Remote;

using Data.Entity;
using Undersoft.SDK;
using Undersoft.SDK.Service.Data.Object;
using Undersoft.SDK.Service.Infrastructure.Repository;
using Undersoft.SDK.Service.Infrastructure.Store;
using Undersoft.SDK.Service.Infrastructure.Store.Remote;

public interface IRemoteProperty<TStore, TOrigin> : IRemoteProperty<TOrigin> where TOrigin : class, IOrigin, IInnerProxy where TStore : IDataServiceStore
{
}

public interface IRemoteProperty<TOrigin> : IRemoteProperty where TOrigin : class, IOrigin, IInnerProxy
{
}

public interface IRemoteProperty : IRepository, IRemoteRelation
{
    bool IsLinked { get; set; }

    IRepository Host { get; set; }

    void Load(object origin);

    Task LoadAsync(object origin);

    void LoadRemoteEvent(object sender, EntityEntryEventArgs e);

    IRemoteSynchronizer Synchronizer { get; }
}

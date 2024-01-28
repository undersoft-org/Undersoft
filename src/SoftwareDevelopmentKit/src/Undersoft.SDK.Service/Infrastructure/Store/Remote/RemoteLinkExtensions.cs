using Microsoft.OData.Edm;
using System.Linq.Expressions;

namespace Undersoft.SDK.Service.Infrastructure.Store.Remote;

using Microsoft.OData.Client;
using Polly;
using Undersoft.SDK.Service.Client;
using Undersoft.SDK.Service.Data.Object;
using Undersoft.SDK.Service.Infrastructure.Store.Relation;
using Uniques;

public static class RemoteLinkExtensions
{
    public static OpenDataContext RemoteSetToSet<TOrigin, TTarget>(this OpenDataContext context,
                                                             Expression<Func<IRelatedLink<TOrigin, TTarget>, object>> middlekey,
                                                             Expression<Func<TTarget, object>> targetkey)
                                                          where TOrigin : class, IOrigin, IInnerProxy
                                                          where TTarget : class, IOrigin, IInnerProxy
    {
        var remote = new RemoteSetToSet<TOrigin, TTarget>(middlekey, targetkey);
        context.Remotes.Put(remote.TypeId, remote);
        context.Remotes.Put(typeof(TOrigin), remote);
        return context;
    }

    public static OpenDataContext RemoteOneToSet<TOrigin, TTarget>(this OpenDataContext context,
                                                             Expression<Func<TOrigin, object>> originkey,
                                                             Expression<Func<TTarget, object>> targetkey)
                                                         where TOrigin : class, IUniqueIdentifiable
                                                         where TTarget : class, IUniqueIdentifiable
    {
       
        var remote = new RemoteOneToSet<TOrigin, TTarget>(originkey, targetkey);
        context.Remotes.Put(remote.TypeId, remote);
        context.Remotes.Put(typeof(TOrigin), remote);
        return context;
    }

    public static OpenDataContext RemoteOneToOne<TOrigin, TTarget>(this OpenDataContext context,
                                                            Expression<Func<TOrigin, object>> originkey,
                                                             Expression<Func<TTarget, object>> targetkey)
                                                        where TOrigin : class, IUniqueIdentifiable
                                                        where TTarget : class, IUniqueIdentifiable
    {
        var remote = new RemoteOneToOne<TOrigin, TTarget>(originkey, targetkey);
        context.Remotes.Put(remote.TypeId, remote);
        context.Remotes.Put(typeof(TOrigin), remote);
        return context;
    }

}


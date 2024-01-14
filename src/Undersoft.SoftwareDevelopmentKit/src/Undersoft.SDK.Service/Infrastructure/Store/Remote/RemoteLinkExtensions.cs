using Microsoft.OData.Edm;
using System.Linq.Expressions;

namespace Undersoft.SDK.Service.Infrastructure.Store.Remote;

using Undersoft.SDK.Service.Data.Object;
using Undersoft.SDK.Service.Data.Relation;
using Uniques;

public static class RemoteLinkExtensions
{
    public static IEdmModel RemoteSetToSet<TOrigin, TTarget>(this IEdmModel builder,
                                                             Expression<Func<IRemoteLink<TOrigin, TTarget>, object>> middlekey,
                                                             Expression<Func<TTarget, object>> targetkey)
                                                          where TOrigin : class, IDataObject
                                                          where TTarget : class, IDataObject
    {
        new RemoteSetToSet<TOrigin, TTarget>(middlekey, targetkey);
        return builder;
    }

    public static IEdmModel RemoteOneToSet<TOrigin, TTarget>(this IEdmModel builder,
                                                             Expression<Func<TOrigin, object>> originkey,
                                                             Expression<Func<TTarget, object>> targetkey)
                                                         where TOrigin : class, IUniqueIdentifiable
                                                         where TTarget : class, IUniqueIdentifiable
    {
        new RemoteOneToSet<TOrigin, TTarget>(originkey, targetkey);
        return builder;
    }

    public static IEdmModel RemoteOneToOne<TOrigin, TTarget>(this IEdmModel builder,
                                                            Expression<Func<TOrigin, object>> originkey,
                                                             Expression<Func<TTarget, object>> targetkey)
                                                        where TOrigin : class, IUniqueIdentifiable
                                                        where TTarget : class, IUniqueIdentifiable
    {
        new RemoteOneToOne<TOrigin, TTarget>(originkey, targetkey);
        return builder;
    }

}


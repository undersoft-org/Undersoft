namespace Undersoft.SDK.Service.Data.Remote;

using Undersoft.SDK.Service.Data.Object;

public class RemoteLink<TSource, TTarget> : RemoteLink, IRemoteLink<TSource, TTarget> where TSource : class, IOrigin, IInnerProxy where TTarget : class, IOrigin, IInnerProxy
{
    public new TSource  LeftEntity { get; set; }

    public new TTarget RightEntity { get; set; }
}

public class RemoteLink : DataObject
{
    public virtual long LeftEntityId { get; set; }

    public virtual object LeftEntity { get; set; }

    public virtual long RightEntityId { get; set; }

    public virtual object RightEntity { get; set; }
}
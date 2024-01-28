namespace Undersoft.SDK.Service.Data.Relation;

using Undersoft.SDK.Service.Data.Object;

public class RemoteLink<TSource, TTarget> : DataObject, IRemoteLink<TSource, TTarget> where TSource : class, IOrigin, IInnerProxy where TTarget : class, IOrigin, IInnerProxy
{
    public virtual long TargetId { get; set; }

    public virtual TTarget Target { get; set; }

    public virtual long SourceId { get; set; }

    public virtual TSource Source { get; set; }
}
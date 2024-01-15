using System.Text.Json.Serialization;

namespace Undersoft.SDK.Service.Data.Relation;

using Entity;

using Undersoft.SDK.Service.Data.Object;
using Uniques;

public interface IRemoteLink<TSource, TTarget> : IDataObject where TSource : class, IOrigin, IInnerProxy where TTarget : class, IOrigin, IInnerProxy
{
    [JsonIgnore]
    TSource Source { get; set; }
    long SourceId { get; set; }
    [JsonIgnore]
    TTarget Target { get; set; }
    long TargetId { get; set; }
}
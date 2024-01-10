using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Undersoft.SDK.Service.Data.Entity;
using Identifier;
using Undersoft.SDK.Service.Data.Object;
using Undersoft.SDK.Service.Data.Object.Detail;
using Undersoft.SDK.Service.Data.Object.Setting;
using Undersoft.SDK.Service.Data.Relation;

[DataContract]
[StructLayout(LayoutKind.Sequential)]
public class OpenEntity<TEntity, TDetail, TSetting, TGroup> : Entity
    where TEntity : IDataObject
    where TDetail : class, IDetail
    where TSetting : class, ISetting
    where TGroup : struct, Enum
{
    public OpenEntity() : base() { }

    [DataMember(Order = 12)]
    public virtual Identifiers<TEntity> Identifiers { get; set; }

    [Details]
    [DataMember(Order = 13)]
    public virtual RelatedSet<TDetail> Details { get; set; }

    [Settings]
    [DataMember(Order = 14)]
    public virtual RelatedSet<TSetting> Settings { get; set; }

    [DataMember(Order = 15)]
    public virtual TGroup Group { get; set; }
}

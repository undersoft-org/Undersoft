using System.ComponentModel.DataAnnotations.Schema;


namespace Undersoft.SDK.Service.Infrastructure.Store.Relation;

using Uniques;

using Undersoft.SDK.Service.Data.Object;
using System.Text.Json.Serialization;

public class RelatedLink<TLeft, TRight> : RelatedLink, IRelatedLink<TLeft, TRight> where TLeft : class, IOrigin, IInnerProxy where TRight : class, IOrigin, IInnerProxy
{    
    [JsonIgnore]
    public virtual TRight RightEntity { get; set; }

    [JsonIgnore]
    public virtual TLeft LeftEntity { get; set; }
}

public class RelatedLink : DataObject
{
    public virtual long? RightEntityId { get; set; }
    public virtual long? LeftEntityId { get; set; }
}
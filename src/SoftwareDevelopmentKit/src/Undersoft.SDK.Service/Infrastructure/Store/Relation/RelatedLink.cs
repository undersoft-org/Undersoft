using System.ComponentModel.DataAnnotations.Schema;


namespace Undersoft.SDK.Service.Infrastructure.Store.Relation;

using Uniques;

using Undersoft.SDK.Service.Data.Object;

public class RelatedLink<TLeft, TRight> : DataObject, IRelatedLink<TLeft, TRight> where TLeft : class, IOrigin, IInnerProxy where TRight : class, IOrigin, IInnerProxy
{
    public virtual long RightEntityId { get; set; }

    public virtual TRight RightEntity { get; set; }

    public virtual long LeftEntityId { get; set; }

    public virtual TLeft LeftEntity { get; set; }
}
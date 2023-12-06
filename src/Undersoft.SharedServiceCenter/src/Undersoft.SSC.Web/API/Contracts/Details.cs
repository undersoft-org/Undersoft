using System.Collections.ObjectModel;
using System.Linq;
using Undersoft.SDK.Series;
using Undersoft.SDK.Uniques;
using Undersoft.SSC.Domain.Entities;
using Undersoft.SSC.Domain.Entities.Enums;

namespace Undersoft.SSC.Web.API.Contracts;

public class Details<TDto> : KeyedCollection<DetailKind, TDto> where TDto : class, IDetail
{
    protected override DetailKind GetKeyForItem(TDto item)
    {
        if (item.Id == 0)
            item.AutoId();
        return item.Kind;
    }

    public TDto Single
    {
        get => this.EnsureOne();
    }

    public TDto? this[string key]
    {
        get
        {
            if (Enum.TryParse(key, out DetailKind detailType))
                return this[detailType];
            return default;
        }
        set
        {
            if (
                Enum.TryParse(key, out DetailKind detailType)
                && Dictionary != null
                && value != null
            )
                Dictionary[detailType] = value;
        }
    }
}

using System.Collections.ObjectModel;

namespace Undersoft.SDK.Service.Data.Object.Detail;

public class Details<TDto> : KeyedCollection<string, TDto> where TDto : class, IDetail
{
    protected override string GetKeyForItem(TDto item)
    {
        if (item.Id == 0)
            item.AutoId();
        return item.Name;
    }

    public TDto Single
    {
        get => this.EnsureOne();
    }

    public new TDto this[string key]
    {
        get
        {
            return this[key];
        }
        set
        {
            if (
                Dictionary != null
                && value != null
            )
                Dictionary[key] = value;
        }
    }
}

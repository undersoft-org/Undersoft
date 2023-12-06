using System.Collections.ObjectModel;
using Undersoft.SDK.Service.Data.Contract;
using Undersoft.SSC.Domain.Entities;
using Undersoft.SSC.Domain.Entities.Enums;

namespace Undersoft.SSC.Web.API.Contracts;

public class Settings<TDto> : KeyedCollection<SettingKind, TDto> where TDto : ISetting, IContract
{
    protected override SettingKind GetKeyForItem(TDto item)
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
            if (Enum.TryParse(key, out SettingKind detailType))
                return this[detailType];
            return default;
        }
        set
        {
            if (
                Enum.TryParse(key, out SettingKind detailType)
                && Dictionary != null
                && value != null
            )
                Dictionary[detailType] = value;
        }
    }
}

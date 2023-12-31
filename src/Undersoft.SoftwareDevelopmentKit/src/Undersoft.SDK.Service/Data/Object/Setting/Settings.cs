using Undersoft.SDK.Service.Data.Object.Detail;

namespace Undersoft.SDK.Service.Data.Object.Setting;

public class Settings<TDto> : Details<TDto> where TDto : class, ISetting
{
    public Settings() { }

    public Settings(IEnumerable<TDto> list) { list.ForEach(item => base.Add(item)); }
}

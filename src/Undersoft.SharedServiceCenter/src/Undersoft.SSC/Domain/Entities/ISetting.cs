using Undersoft.SSC.Domain.Entities.Enums;

namespace Undersoft.SSC.Domain.Entities
{
    public interface ISetting : IDataObject

    {
        SettingKind Kind { get; set; }
        string? Name { get; set; }
    }
}
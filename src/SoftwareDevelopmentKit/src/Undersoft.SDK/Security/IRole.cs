using Undersoft.SDK.Series;

namespace Undersoft.SDK.Security
{
    public interface IRole
    {
        string Name { get; set; }
        string NormalizedName { get; set; }
    }
}
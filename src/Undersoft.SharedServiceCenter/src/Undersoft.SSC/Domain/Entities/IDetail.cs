using Undersoft.SSC.Domain.Entities.Enums;

namespace Undersoft.SSC.Domain.Entities
{
    public interface IDetail : IDataObjectDetail
    {
        DetailKind Kind { get; set; }
        string? Name { get; set; }
    }
}
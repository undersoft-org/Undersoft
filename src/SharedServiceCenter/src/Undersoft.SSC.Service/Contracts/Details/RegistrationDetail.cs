using Undersoft.SDK.Service.Data.Object.Detail;
using Undersoft.SSC.Entities.Enums;

namespace Undersoft.SSC.Service.Contracts.Details;

[Detail]
public class RegistrationDetail : DataObject
{
    public RegistrationDetail() { }

    public RegistrationKind? Kind { get; set; }

    public bool? Completed { get; set; }

    public bool? Approved { get; set; }
}

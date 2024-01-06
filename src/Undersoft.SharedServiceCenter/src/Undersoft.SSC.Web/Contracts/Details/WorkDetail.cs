using Undersoft.SDK.Service.Data.Object.Detail;

namespace Undersoft.SSC.Web.Contracts.Details;

[Detail]
public class WorkDetail : DataObject
{
    public WorkDetail() { }

    public string? Name { get; set; }

    public string? Description { get; set; }

}

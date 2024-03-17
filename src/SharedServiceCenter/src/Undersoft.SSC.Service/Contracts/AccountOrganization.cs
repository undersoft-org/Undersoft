using Undersoft.SDK.Rubrics.Attributes;

namespace Undersoft.SSC.Service.Contracts;

public class AccountOrganization : DataObject
{
    [VisibleRubric]
    public string? Industry { get; set; }

    [VisibleRubric]
    [DisplayRubric("Short name")]
    public string? Name { get; set; }

    [VisibleRubric]
    [DisplayRubric("Full name")]
    public string? FullName { get; set; }

    [VisibleRubric]
    public string? Position { get; set; }

    public long? AccountId { get; set; }
}

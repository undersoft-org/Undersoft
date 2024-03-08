using Undersoft.SDK.Rubrics.Attributes;

namespace Undersoft.SSC.Service.Contracts;

public class AccountOrganization : DataObject
{
    [VisibleRubric]
    public string? Industry { get; set; }

    [VisibleRubric]
    public string? Name { get; set; }

    [VisibleRubric]
    public string? FullName { get; set; }

    [VisibleRubric]
    public string? Position { get; set; }

    [VisibleRubric]
    public string? Email { get; set; }

    [VisibleRubric]
    public string? PhoneNumber { get; set; }

    [VisibleRubric]
    public string? Image { get; set; }

    public long? AccountId { get; set; }
}

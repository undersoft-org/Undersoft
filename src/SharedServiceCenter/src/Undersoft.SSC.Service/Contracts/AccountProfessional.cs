using Undersoft.SDK.Rubrics.Attributes;

namespace Undersoft.SSC.Service.Contracts;

public class AccountProfessional : DataObject
{
    [VisibleRubric]
    public string Industry { get; set; } = default!;

    [VisibleRubric]
    public string Profession { get; set; } = default!;

    [VisibleRubric]
    public string Email { get; set; } = default!;

    [VisibleRubric]
    public string PhoneNumber { get; set; } = default!;

    [VisibleRubric]
    public string SocialMedia { get; set; } = default!;

    [VisibleRubric]
    public string Websites { get; set; } = default!;

    [VisibleRubric]
    public float Experience { get; set; }

    public long AccountId { get; set; }
}
